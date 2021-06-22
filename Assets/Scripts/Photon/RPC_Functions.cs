using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class RPC_Functions : MonoBehaviourPunCallbacks
{
    [PunRPC]
    void DestroyPlatform(string name){
        Destroy(GameObject.Find(name));
    }
    [PunRPC]
    void TeleportPlayer(string name,Vector3 position){
        GameObject player = GameObject.Find(name);
        player.transform.position = position;
    }
    [PunRPC]
    void UpdateUIPlayersInfo(){
        GameObject.Find("PlayersDisplay").GetComponent<UIPlayersDisplay>().UpdateUIPlayersInfo();
    }
    [PunRPC]
    void InactiveObject(string name){
        GameObject.Find(name).SetActive(false);
    }
}
