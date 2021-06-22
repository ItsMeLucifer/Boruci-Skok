using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class CameraScript : MonoBehaviourPunCallbacks
{
    public GameObject cameraTarget;
    public GameObject[] players;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        if(players.Length == 0){
            players = GameObject.FindGameObjectsWithTag("Player");
        }
        if(cameraTarget == null && players.Length > 1){
            foreach (GameObject player in players){
                Debug.Log("PLayer name: "+player.name);
                if(player.GetComponent<PhotonView>().IsMine){
                    cameraTarget = player;
                    break;
                }
            }
        }
        if(cameraTarget == null && players.Length == 1){
            cameraTarget = players[0];
        }
        if(cameraTarget.transform.position.y > transform.position.y+5.4025f){
            transform.position = new Vector3(0,transform.position.y + 10.805f,-10f);
        }
        if(cameraTarget.transform.position.y < transform.position.y-5.4025f){
            transform.position = new Vector3(0,transform.position.y - 10.805f,-10f);
        }
    }
}
