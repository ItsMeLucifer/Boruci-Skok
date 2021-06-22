using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementScript : MonoBehaviour
{
    private float patrolStartPoint;
    [SerializeField] private float patrolEndPoint;
    private float currentTarget;
    void Start(){
        patrolStartPoint = transform.position.x;
        currentTarget = patrolEndPoint;
    }
    void Update()
    {
        if(Vector3.Distance(transform.position,new Vector3(patrolStartPoint,transform.position.y,transform.position.z)) < 0.01f)
            currentTarget = patrolEndPoint;
        if(Vector3.Distance(transform.position,new Vector3(patrolEndPoint,transform.position.y,transform.position.z)) < 0.01f)
            currentTarget = patrolStartPoint;
        transform.position = Vector3.Lerp(transform.position,new Vector3(currentTarget,transform.position.y,transform.position.z),0.01f);
    }
}
