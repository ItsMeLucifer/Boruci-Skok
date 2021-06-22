using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class IgnoreScripts : MonoBehaviourPunCallbacks
{
    [SerializeField] private Component[] componentsToIgnore;
    void Start()
    {
        if(GetComponent<PhotonView>()){
            if(!GetComponent<PhotonView>().IsMine ){
                foreach(Component component in componentsToIgnore){
                Destroy(component);
            }
        }
        }else{
            if(!transform.parent.gameObject.GetComponent<PhotonView>().IsMine){
                foreach(Component component in componentsToIgnore){
                Destroy(component);
            }
        }
    }
    }
}
