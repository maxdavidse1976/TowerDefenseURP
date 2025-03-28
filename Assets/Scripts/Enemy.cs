using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] _waypoints;

    int _waypointIndex;
    NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (_agent.remainingDistance < .5f)
        {
            _agent.SetDestination(GetNextWaypoint());
        }
    }

    Vector3 GetNextWaypoint()
    {
        if (_waypointIndex >= _waypoints.Length)
        {
            return transform.position;
        }

        Vector3 targetPoint = _waypoints[ _waypointIndex].position;
        _waypointIndex++;

        return targetPoint;
    }
}
