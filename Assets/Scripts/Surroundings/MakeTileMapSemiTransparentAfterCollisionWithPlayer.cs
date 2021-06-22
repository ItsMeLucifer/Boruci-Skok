using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
public class MakeTileMapSemiTransparentAfterCollisionWithPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            GetComponent<Tilemap>().color = new Color(1f,1f,1f,0.5f);
        }
    }
}
