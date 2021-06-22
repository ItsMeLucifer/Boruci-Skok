using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class LeavePhotonRoom : MonoBehaviourPunCallbacks
{
    public void LeaveRoom(){
        PhotonNetwork.Disconnect();
    }
}
