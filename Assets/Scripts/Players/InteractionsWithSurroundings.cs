using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InteractionsWithSurroundings : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "MovingPlatform"){
            transform.parent = col.gameObject.transform;
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "MovingPlatform"){
            transform.parent = null;
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="Beer"){
            if(GameObject.Find("SinglePlayerManager") == null){
                GetComponent<Player_Movement>().enabled = false;
                GetComponent<SpectatorMode>().start = true;
                if(GameObject.Find("GameManager").GetComponent<GameManager>().playersEndedGame.Find(x=> x==gameObject) == null){
                    GameObject.Find("GameManager").GetComponent<GameManager>().playersEndedGame.Add(gameObject);
                }
            }else{
                SceneManager.LoadScene("End");
            }
        }
    }
}
