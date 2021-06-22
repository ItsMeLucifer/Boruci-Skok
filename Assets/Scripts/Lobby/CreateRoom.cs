using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;
    private Text roomName

    {
        get{return _roomName;}
    }
    public void OnClick_CreateRoom()
    {
        GameObject.Find("RoomNameTitle").GetComponent<Text>().text = "'" + roomName.text + "' Room";
        if (PhotonNetwork.CreateRoom(roomName.text, new RoomOptions { IsVisible = true,IsOpen = true, MaxPlayers = 7 }, TypedLobby.Default))
            Debug.Log("create room successfully sent");
        else
            Debug.Log("create room failed to send");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Room created successfully");
        GameObject.Find("UI").GetComponent<MainCanvasManager>().currentRoomCanvas.transform.SetAsLastSibling();
    }
}
