using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class SpectatorMode : MonoBehaviourPunCallbacks
{
    private GameObject mainCamera;
    private GameObject[] localPlayers;
    private GameObject currentTarget;
    public bool start = false;
    [SerializeField] private GameObject spectatorModePrefab;
    private GameObject spectatorModeUI;
    private int currentPlayer = 0;
    private bool newData = false;
    void Start(){
        if(GetComponent<PhotonView>().IsMine){
            mainCamera = GameObject.Find("Main Camera");
            spectatorModeUI = Instantiate(spectatorModePrefab,new Vector3(0,0,0),Quaternion.identity);
            spectatorModeUI.transform.SetParent(GameObject.Find("UI").transform,false);
            spectatorModeUI.SetActive(false);
        }
    }
    void Update(){
        if(start && GetComponent<PhotonView>().IsMine){
            //USTAWIC BLOKOWANIE ULTA
            newData = false;
            if(!spectatorModeUI.activeSelf) spectatorModeUI.SetActive(true);
            if(localPlayers == null || localPlayers.Length == 0 ) localPlayers = GameObject.FindGameObjectsWithTag("Player");
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                currentPlayer--;
                if(currentPlayer<0){
                    currentPlayer = localPlayers.Length -1;
                }
                newData = true;
            }
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
                currentPlayer++;
                if(currentPlayer>localPlayers.Length-1){
                    currentPlayer = 0;
                }
                newData = true;
            }
            if(newData){
                currentTarget = localPlayers[currentPlayer];
                mainCamera.GetComponent<CameraScript>().cameraTarget = currentTarget;
            }
        }
    }
}
