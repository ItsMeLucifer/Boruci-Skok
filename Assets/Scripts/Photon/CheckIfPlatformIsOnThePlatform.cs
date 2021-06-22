using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlatformIsOnThePlatform : MonoBehaviour
{
    void onCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Platform" || col.gameObject.tag == "Surroundings"){
            Destroy(gameObject);
        }
    }
}
