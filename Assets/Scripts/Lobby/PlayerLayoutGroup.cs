using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerLayoutGroup : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _playerListingPrefab;
    private GameObject playerListingPrefab
    {
        get { return _playerListingPrefab; }
    }
    private List<PlayerListing> _playerListings = new List<PlayerListing>();
    private List<PlayerListing> playerListings
    {
        get { return _playerListings; }
    }
    private List<Player> _photonPlayerListings = new List<Player>();
    private List<Player> photonPlayerListings
    {
        get { return _photonPlayerListings; }
    }

    public override void OnJoinedRoom()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        MainCanvasManager.instance.currentRoomCanvas.transform.SetAsLastSibling();
        Player[] photonPlayers = PhotonNetwork.PlayerList;
        for(int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
    }
    public override void OnPlayerEnteredRoom(Player photonPlayer)
    {
        PlayerJoinedRoom(photonPlayer);
    }
    public override void OnPlayerLeftRoom(Player photonPlayer)
    {
        PlayerLeftRoom(photonPlayer);
    }
    private void PlayerJoinedRoom(Player photonPlayer)
    {
        if (photonPlayer == null) return;
        PlayerLeftRoom(photonPlayer);
        GameObject playerListingObj = Instantiate(playerListingPrefab);
        playerListingObj.transform.SetParent(transform, false);
        PlayerListing playerListing = playerListingObj.GetComponent<PlayerListing>();
        playerListing.ApplyPhotonPlayer(photonPlayer);
        photonPlayerListings.Add(photonPlayer);
        playerListings.Add(playerListing);
    }
    private void PlayerLeftRoom(Player photonPlayer)
    {
        int index = -1;
        index = playerListings.FindIndex(x => x.playerName.text == photonPlayer.NickName);
        if(index != -1)
        {
            Destroy(playerListings[index].gameObject);
            playerListings.RemoveAt(index);
        }
    }
    
    public void ChangeRoomVisibility()
    {
        if (!PhotonNetwork.IsMasterClient)
        {

        }
        PhotonNetwork.CurrentRoom.IsOpen = !PhotonNetwork.CurrentRoom.IsOpen;
        PhotonNetwork.CurrentRoom.IsVisible = PhotonNetwork.CurrentRoom.IsOpen;
        Debug.Log("Visibility: " + PhotonNetwork.CurrentRoom.IsVisible);
    }
    public void startUpdating(){
        StartCoroutine("Updating");
    }
    public void stopUpdating(){
        StopCoroutine("Updating");
    }
    IEnumerator Updating(){
        for(;;){
            updatePlayers();
            yield return new WaitForSeconds(0.1f);
        }
    }
    void updatePlayers(){
        Player[] photonPlayers = PhotonNetwork.PlayerList;
        GameObject[] listings = GameObject.FindGameObjectsWithTag("PlayerListing");
        for(int i = 0; i< listings.Length;i++){
            listings[i].GetComponent<PlayerListing>().ApplyPhotonPlayer(photonPlayers[i]);
        }
    }
}
