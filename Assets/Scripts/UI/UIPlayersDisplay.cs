using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UIPlayersDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerUIPrefab;
    private Player[] players;
    private GameObject[] localPlayers;
    void Start()
    {
        localPlayers = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if(localPlayers.Length == 0){
            localPlayers = GameObject.FindGameObjectsWithTag("Player");
        }else{
            UpdateUIPlayersInfo();
        }
    }
    public void UpdateUIPlayersInfo(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
        players = PhotonNetwork.PlayerList;
        for(int i = 0; i< players.Length;i++){
            GameObject g = Instantiate(playerUIPrefab,transform.position,Quaternion.identity);
            g.transform.SetParent(transform);
            g.GetComponent<UIPlayerListing>().GetInfo(players[i]);
            g.transform.localScale = new Vector3(1f,1f,1f);
        }
    }
}

