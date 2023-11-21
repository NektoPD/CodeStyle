using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPosition;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPosition];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            MoveToNextTarget();
        }
    }

    private void MoveToNextTarget()
    {
        _currentPosition++;

        if (_currentPosition >= _points.Length)
        {
            _currentPosition = 0;
        }
    }
}