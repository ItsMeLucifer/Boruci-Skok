using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class SetCharacter : MonoBehaviourPunCallbacks
{
    public void SetCharacterPlayer(string name){
        Hashtable hash = new Hashtable();
        hash.Add("Ultimates", 20);
        hash.Add("Character", name);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}
