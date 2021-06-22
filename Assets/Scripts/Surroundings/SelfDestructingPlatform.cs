using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SelfDestructingPlatform : MonoBehaviour
{
    [SerializeField] private int maxPlayers;
    [SerializeField] private TextMeshPro text;
    private int numberOfPlayers = 0;
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "GroundDetector"){
            numberOfPlayers++;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.tag == "GroundDetector"){
            numberOfPlayers--;
        }
    }
    void Update(){
        if(numberOfPlayers > maxPlayers){
            Destroy(gameObject);
        }
        text.text = (maxPlayers - numberOfPlayers).ToString();
    }
}
