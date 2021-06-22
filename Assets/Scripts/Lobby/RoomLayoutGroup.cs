using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class RoomLayoutGroup : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _roomListingPrefab;
    private GameObject roomListingPrefab
    {
        get { return _roomListingPrefab; }
    }

    private List<RoomListing> _roomListingButtons = new List<RoomListing>();
    private List<RoomListing> roomListingButtons
    {
        get { return _roomListingButtons; }
    }

    public override void OnRoomListUpdate(List<RoomInfo> rooms)
    {
        foreach (RoomInfo room in rooms)
        {
            RoomReceived(room);
        }
        RemoveOldRooms();
    }
    public void RoomReceived(RoomInfo room)
    {
        int index = -1;
        index = roomListingButtons.FindIndex(x => x.roomName == room.Name);
        if(index == -1)
        {
            if(room.IsVisible && room.IsOpen && room.PlayerCount < room.MaxPlayers)
            {
                GameObject roomListingObj = Instantiate(roomListingPrefab);
                roomListingObj.transform.SetParent(transform, false);
                RoomListing roomListing = roomListingObj.GetComponent<RoomListing>();
                roomListingButtons.Add(roomListing);

                index = (roomListingButtons.Count - 1);
            }
        }
        if(index != -1)
        {
            RoomListing roomListing = roomListingButtons[index];
            roomListing.SetRoomNameText(room.Name);
            roomListing.updated = true;
        }
        if (!room.IsVisible)
        {
            roomListingButtons[roomListingButtons.Count - 1].SetRoomNameText("(Closed)");
        }
    }

    private void RemoveOldRooms()
    {
        List<RoomListing> removeRooms = new List<RoomListing>();
        foreach(RoomListing roomListing in roomListingButtons)
        {
            if (!roomListing.updated)
                removeRooms.Add(roomListing);
            else
                roomListing.updated = false;
        }
        foreach(RoomListing roomListing in removeRooms)
        {
            GameObject roomListingObj = roomListing.gameObject;
            roomListingButtons.Remove(roomListing);
            Destroy(roomListingObj);
        }
    }
    public void OnClickLeaveRoom()
    {
        Hashtable hash = new Hashtable();
        hash.Add("Character", "");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        PhotonNetwork.LeaveRoom();
    }
}
