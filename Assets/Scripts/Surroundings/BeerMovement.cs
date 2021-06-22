using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerMovement : MonoBehaviour
{
    private float maxY;
    private float minY;
    private float difference = 0.002f;
    void Start()
    {
        maxY = transform.position.y+0.05f;
        minY = transform.position.y-0.05f;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y+difference,transform.position.z);
        if(transform.position.y >= maxY){
            difference*=-1;
        }
        if(transform.position.y <= minY){
            difference*=-1;
        }
    }
}
