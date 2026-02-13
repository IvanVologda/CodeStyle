using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform PointParrent;
    [SerializeField] private float _speed;
    private Transform[] _points;
    private int currentIndex;

    private void Start()
    {
        int count = PointParrent.childCount;
        _points = new Transform[count];

        for (int i = 0; i < PointParrent.childCount; i++)
            _points[i] = PointParrent.GetChild(i);
    }

    private void Update()
    {
        Transform currentTarget = _points[currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.05f) 
            SetNextTarget();
    }

    public void SetNextTarget()
    {
        currentIndex++;

        if (currentIndex >= _points.Length)
            currentIndex = 0;

        Vector3 direction = _points[currentIndex].position - transform.position;
        transform.forward = direction.normalized;
    }
}
