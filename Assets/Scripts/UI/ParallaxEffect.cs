using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ParallaxEffect : MonoBehaviourPunCallbacks
{
    private GameObject[] localPlayers;
    private GameObject localPlayer;
    [SerializeField] private GameObject foreground;
    [SerializeField] private GameObject layer2;
    [SerializeField] private GameObject layer3;
    private Vector3 startingPosition;
    [SerializeField] private float y_diff = 0f;
    void Start()
    {
        localPlayers = GameObject.FindGameObjectsWithTag("Player");
        startingPosition = foreground.transform.position;
    }

    void Update()
    {
        if(localPlayers.Length < 1){
            localPlayers = GameObject.FindGameObjectsWithTag("Player");
        }
        if(localPlayers.Length > 1){
            localPlayer = GameObject.Find("Main Camera").GetComponent<CameraScript>().cameraTarget;
        }
        if(localPlayer == null && localPlayers.Length == 1){
            localPlayer = localPlayers[0];
        }
        if(localPlayer.transform.position.y > y_diff){
            foreground.transform.position = new Vector3(startingPosition.x,startingPosition.y-(localPlayer.transform.position.y-y_diff)/10,0f);
            if(layer2 != null)layer2.transform.position = new Vector3(startingPosition.x,startingPosition.y-(localPlayer.transform.position.y-y_diff)/20,0f);
            if(layer3 != null)layer3.transform.position = new Vector3(startingPosition.x,startingPosition.y-(localPlayer.transform.position.y-y_diff)/30,0f);
        }
    }
}
