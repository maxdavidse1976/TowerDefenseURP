using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveDetails
{
    public int basicEnemy;
    public int fastEnemy;
}

public class EnemyManager : MonoBehaviour
{
    [SerializeField] WaveDetails _currentWave;
    
    [Space]

    [SerializeField] Transform _respawnPoint;
    [SerializeField] float _spawnCooldown;
    
    [Space]

    [Header("Enemy prefabs")]
    [SerializeField] GameObject _basicEnemy;
    [SerializeField] GameObject _fastEnemy;

    float spawnTimer;
    List<GameObject> _enemiesToCreate;

    void Start()
    {
        _enemiesToCreate = NewEnemyWave();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && _enemiesToCreate.Count > 0)
        {
            CreateEnemy();
            spawnTimer = _spawnCooldown;
        }
    }

    void CreateEnemy()
    {
        GameObject randomEnemy = SpawnRandomEnemy();
        GameObject newEnemy = Instantiate(randomEnemy, _respawnPoint.position, Quaternion.identity);
    }

    GameObject SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, _enemiesToCreate.Count);
        GameObject chosenEnemy = _enemiesToCreate[randomIndex];

        _enemiesToCreate.Remove(chosenEnemy);

        return chosenEnemy;
    }

    List<GameObject> NewEnemyWave()
    {
        List<GameObject> newEnemyList = new List<GameObject>();
        for (int i = 0; i < _currentWave.basicEnemy; i++)
        {
            newEnemyList.Add(_basicEnemy);
        }
        for (int i = 0; i < _currentWave.fastEnemy; i++)
        {
            newEnemyList.Add(_fastEnemy);
        }
        return newEnemyList;
    }
}
