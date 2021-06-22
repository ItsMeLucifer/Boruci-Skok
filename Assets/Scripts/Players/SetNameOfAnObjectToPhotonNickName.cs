using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class SetNameOfAnObjectToPhotonNickName : MonoBehaviourPunCallbacks
{
    void Update()
    {
        if(gameObject.GetComponent<PhotonView>().Owner.NickName != gameObject.name){
            gameObject.name = gameObject.GetComponent<PhotonView>().Owner.NickName;
        }
    }
}
