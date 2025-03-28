using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform _waypoint;

    NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _agent.SetDestination(_waypoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
