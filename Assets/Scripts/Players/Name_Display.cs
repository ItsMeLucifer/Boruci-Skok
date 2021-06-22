using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class Name_Display : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject parent;

    void Update()
    {
        GetComponent<TextMeshPro>().text = parent.GetComponent<PhotonView>().Owner.NickName;
    }
}
