using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField] Transform[] _waypoints;

    public Transform[] GetWaypoints() => _waypoints;
}
