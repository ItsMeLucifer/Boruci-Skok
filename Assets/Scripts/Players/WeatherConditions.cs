using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherConditions : MonoBehaviour
{
    public float windForce = 500f; 
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "RightWind"){
            GetComponent<Player_Movement>().horizontalAdditionalForce = windForce;
        }
        if(col.tag == "LeftWind"){
            GetComponent<Player_Movement>().horizontalAdditionalForce = -windForce;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.tag == "RightWind" || col.tag == "LeftWind"){
            GetComponent<Player_Movement>().horizontalAdditionalForce = 0f;
        }
    }
}
