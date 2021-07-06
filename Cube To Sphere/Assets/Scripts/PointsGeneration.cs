using UnityEngine;
using UnityEngine.Events;

public class PointsGeneration : MonoBehaviour
{
    private readonly float maxPlatformCords = 5f;
    private readonly float minPlatformCords = -5f;

    [SerializeField] private GameObject pointPrefab;

    public UnityEvent<Transform> OnPointCreate = new UnityEvent<Transform>();


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            createPoint();
        }

    }
    private void createPoint()
    {
        GameObject point = Instantiate(pointPrefab);
        point.transform.localPosition = generatePosition();
        OnPointCreate.Invoke(point.transform);
    }
    private Vector3 generatePosition()
    {
        return new Vector3(Random.Range(maxPlatformCords, minPlatformCords), 0.25f, Random.Range(maxPlatformCords, minPlatformCords));
    }
}
