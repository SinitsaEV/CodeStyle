using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform _wayPointsParent;
    [SerializeField] private Transform[] _wayPoints;
    private int _wayPointIndex = 0;

    private void Awake()
    {
        _wayPoints = new Transform[_wayPointsParent.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
            _wayPoints[i] = _wayPointsParent.GetChild(i);
    }

    private void Update()
    {
        Transform currentWayPoint = _wayPoints[_wayPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, _speed * Time.deltaTime);


        if (transform.position == currentWayPoint.position) 
            SelectNextWayPoint();
    }

    private void SelectNextWayPoint()
    {
        _wayPointIndex = (_wayPointIndex + 1) % _wayPoints.Length;
    }
}