using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class InteractionsWithNPC : MonoBehaviourPunCallbacks
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Keyholder"){
            if(GameObject.Find("SinglePlayerManager") == null){
                GetComponent<PhotonView>().RPC("DestroyPlatform",RpcTarget.All,"Platform 16 Block");
                GetComponent<PhotonView>().RPC("DestroyPlatform",RpcTarget.All,"Platform 16 Block 2");
                GetComponent<PhotonView>().RPC("DestroyPlatform",RpcTarget.All,"LightHouseToDestroy");
            }else{
                Destroy(GameObject.Find("Platform 16 Block"));
                Destroy(GameObject.Find("Platform 16 Block 2"));
                Destroy(GameObject.Find("LightHouseToDestroy"));
            }
            
        }
    }
}
