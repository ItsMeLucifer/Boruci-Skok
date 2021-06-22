using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class RoomListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomNameText;
    private Text roomNameText
    {
        get { return _roomNameText; }
    }
    public string roomName { get; private set; }
    public bool updated { get; set; }
    [SerializeField] private Text playersCount;
    private GameObject lobbyNetwork;
    void Start()
    {
        lobbyNetwork = GameObject.Find("LobbyNetwork");
        GameObject lobbyCanvasObj = MainCanvasManager.instance.lobbyCanvas.gameObject;
        if (lobbyCanvasObj == null)
            return;
        LobbyCanvas lobbyCanvas = lobbyCanvasObj.GetComponent<LobbyCanvas>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => lobbyCanvas.OnClickJoinRoom(roomNameText.text));
    }
    public void GetRoomNameAfterClick()
    {
        GameObject.Find("RoomNameTitle").GetComponent<Text>().text = "'"+roomNameText.text+"' Room";
    }
    private void OnDestroy()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
    }
    public void SetRoomNameText(string text)
    {
        roomName = text;
        roomNameText.text = roomName;
    }
    void Update(){
        if(lobbyNetwork.GetComponent<LobbyNetwork>().cachedRoomList.Count != 0){
            SetPlayersCount();
        }
    }
    public void StartUpdatingPlayersDetails(){
        GameObject.Find("PlayerListLayoutGroup").GetComponent<PlayerLayoutGroup>().startUpdating();
    }
    public void StartPreventingDuplication(){
        GameObject.Find("LobbyNetwork").GetComponent<LobbyNetwork>().StartPreventingDuplication();
    }
    private void SetPlayersCount(){
        Debug.Log("Set Players Count");
        foreach(KeyValuePair<string, RoomInfo> room in lobbyNetwork.GetComponent<LobbyNetwork>().cachedRoomList){
            if(room.Key == roomName){
                playersCount.text = room.Value.PlayerCount.ToString()+"/"+room.Value.MaxPlayers.ToString();
            }
        }
    }
}
