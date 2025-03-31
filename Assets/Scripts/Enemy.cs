using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] _waypoints;
    [SerializeField] float _turnSpeed = 10;

    int _waypointIndex;
    NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.avoidancePriority = Mathf.RoundToInt(_agent.speed * 10);
    }
    void Update()
    {
        FaceTarget(_agent.steeringTarget);
        if (_agent.remainingDistance < .5f)
        {
            _agent.SetDestination(GetNextWaypoint());
        }
    }

    void FaceTarget(Vector3 newTarget)
    {
        Vector3 directionToTarget = newTarget - transform.position;
        directionToTarget.y = 0; // removes vertical rotation
        Quaternion newRotation = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, _turnSpeed * Time.deltaTime);
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
