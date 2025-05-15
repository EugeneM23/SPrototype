using UnityEngine;

public class ProjectileArcMover : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private float speed;
    [SerializeField] private float height;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float startTime;
    private float totalDistance;

    void Update()
    {
        float timePassed = (Time.time - startTime);
        float distanceCovered = timePassed * speed;

        float t = distanceCovered / totalDistance;

        if (t >= 1f)
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            transform.position = _endPosition;
            return;
        }

        Vector3 currentPos = GetParabolaPoint(_startPosition, _endPosition, t);
        transform.position = currentPos;
    }

    public void Construct(Vector3 start, Vector3 end)
    {
        _startPosition = start;
        _endPosition = end;
        transform.position = start;

        totalDistance = Vector3.Distance(_startPosition, _endPosition);
        startTime = Time.time;
    }

    private Vector3 GetParabolaPoint(Vector3 start, Vector3 end, float t)
    {
        Vector3 point = Vector3.Lerp(start, end, t);

        float parabolicHeight = height * t * (1 - t);
        point.y += parabolicHeight;

        return point;
    }
}