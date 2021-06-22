using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountScript : MonoBehaviour
{
    public Vector3 destination = new Vector3(0,0,0);
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,destination,0.1f);
    }
}
