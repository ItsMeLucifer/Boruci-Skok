using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class UnBugThePlayer : MonoBehaviourPunCallbacks
{
    public void UnBug(){
        GameObject[] localPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in localPlayers){
            if(player.GetComponent<PhotonView>().IsMine){
                player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y+0.5f,0);
            }
        }
    }
}
