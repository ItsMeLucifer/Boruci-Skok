using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float startRotation;
    [SerializeField] private float endRotation;
    [SerializeField] private float valueToAdd;
    void Start()
    {
    }
    void Update()
    {
        
        transform.Rotate(new Vector3(0,0,valueToAdd),Space.Self);
        if(Mathf.Abs(Mathf.Abs(transform.eulerAngles.z)-Mathf.Abs(endRotation))<3){
            valueToAdd *=-1;
        }
        if(Mathf.Abs(transform.eulerAngles.z-startRotation)<3){
            valueToAdd *=-1;
        }
        
    }
}
