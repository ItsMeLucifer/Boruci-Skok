using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysInTheSamePosition : MonoBehaviour
{
    public GameObject objectToPin;
    void Update()
    {
        transform.position = new Vector3(objectToPin.transform.position.x,objectToPin.transform.position.y,0);
    }
}
