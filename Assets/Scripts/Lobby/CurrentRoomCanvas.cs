
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class CurrentRoomCanvas : MonoBehaviourPunCallbacks
{
    public void OnClickStartSync()
    {
        if (!PhotonNetwork.IsMasterClient){

            return;
        }
        PhotonNetwork.LoadLevel(3);
    }
}
