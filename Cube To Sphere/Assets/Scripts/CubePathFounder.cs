using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class CubePathFounder : MonoBehaviour, ICube
{
  
    [SerializeField] private float cubeSpeed ;
    [SerializeField] private float cubeRotationSpeed ;
    [SerializeField] private ParticleSystem ParticleSystem ;

    private List<Transform> pointsList;
    private Transform curentTarget;
    private bool isCanWork => pointsList.Any();

    public UnityEvent OnPointsAdd  = new UnityEvent();

    private void Start()
    {
        pointsList = new List<Transform>();
    }
    private void FixedUpdate()
    {
        if (isCanWork)
        {
            getClosest();
            rotateToClosest();
            goToClotest();
            
        }
    }
    
    private void rotateToClosest()
    {
        
        Vector3 direction = (new Vector3(curentTarget.position.x,0, curentTarget.position.z)  - new Vector3(transform.position.x, 0, transform.position.z)).normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * cubeRotationSpeed);
             

    }
    private void goToClotest()
    {
        Vector3 direction = new Vector3(curentTarget.position.x,transform.position.y, curentTarget.position.z);
        transform.position += transform.forward *Time.deltaTime * cubeSpeed;
        
    }
   private void getClosest()
    {
        Transform bestTarget = null;
        if (isCanWork)
        {
           
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;
            foreach (Transform nearest in pointsList)
            {      
                 Vector3 directionToTarget = nearest.position - currentPosition;
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    if (dSqrToTarget < closestDistanceSqr)
                    {
                        closestDistanceSqr = dSqrToTarget;
                        bestTarget = nearest;
                    }
                }
                
            }
            curentTarget = bestTarget;
            
        }
        
    
    public void AddToList(Transform pointPosition)
    {
        pointsList.Add(pointPosition);
       
    }
    public void AddPoints(GameObject gameObject)
    {
        ParticleSystem.Play();
        pointsList.Remove(gameObject.transform);
        OnPointsAdd.Invoke();
       
    }
}
