using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform _respawnPoint;
    [SerializeField] float spawnCooldown;

    [Header("Enemy prefabs")]
    [SerializeField] GameObject _basicEnemy;

    float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;   
        if (spawnTimer <= 0)
        {
            CreateEnemy();
            spawnTimer = spawnCooldown;
        }
    }

    private void CreateEnemy()
    {
        GameObject newEnemy = Instantiate(_basicEnemy, _respawnPoint.position, Quaternion.identity);
    }
}
