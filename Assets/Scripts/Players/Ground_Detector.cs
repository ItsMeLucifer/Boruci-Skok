using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Detector : MonoBehaviour
{
    public bool isOnThePlatform = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Platform" || col.tag == "Surroundings" || col.tag == "MovingPlatform"){
            isOnThePlatform = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.tag == "Platform" || col.tag == "Surroundings" || col.tag == "MovingPlatform"){
            isOnThePlatform = false;
        }
    }
}
