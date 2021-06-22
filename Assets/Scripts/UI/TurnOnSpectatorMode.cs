using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class TurnOnSpectatorMode : MonoBehaviourPunCallbacks
{
    private GameObject myPlayer;
    void Start(){
        GameObject[] localPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in localPlayers){
            if(player.GetComponent<PhotonView>().IsMine){
                myPlayer = player;
                break;
            }
        }
    }
    public void StartSpectatorMode(){
        myPlayer.GetComponent<Player_Movement>().enabled = false;
        myPlayer.GetComponent<SpectatorMode>().start = true;
        transform.parent.parent.gameObject.GetComponent<UIHandler>().ChangeSpectatorModeButtonsVisibility();
    }
    public void StopSpectatorMode(){
        myPlayer.GetComponent<Player_Movement>().enabled = true;
        myPlayer.GetComponent<SpectatorMode>().start = false;
        GameObject.Find("Spectator Mode(Clone)").SetActive(false);
        transform.parent.parent.gameObject.GetComponent<UIHandler>().ChangeSpectatorModeButtonsVisibility();
        GameObject.Find("Main Camera").GetComponent<CameraScript>().players = null;
        GameObject.Find("Main Camera").GetComponent<CameraScript>().cameraTarget = null;
    }
}
