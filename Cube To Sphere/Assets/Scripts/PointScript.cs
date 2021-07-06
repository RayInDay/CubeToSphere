using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class PointScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ICube>().AddPoints(gameObject);
        Destroy(gameObject);
       
    }
}
