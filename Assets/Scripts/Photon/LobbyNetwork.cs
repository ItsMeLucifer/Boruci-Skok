using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    public GameObject reloadAnimation;
    [SerializeField] private Button platformerButton;
    [SerializeField] private Button destroyerButton;
    [SerializeField] private Button teleporterButton;
    [SerializeField] private Button timeLeaperButton;
    [SerializeField] private Button windMasterButton;
    [SerializeField] private Button evilWzardButton;
    [SerializeField] private Button medievalKingButton;
    [SerializeField] private Image platformerAvatar;
    [SerializeField] private Image destroyerAvatar;
    [SerializeField] private Image teleporterAvatar;
    [SerializeField] private Image timeLeaperAvatar;
    [SerializeField] private Image windMasterAvatar;
    [SerializeField] private Image evilWzardAvatar;
    [SerializeField] private Image medievalKingAvatar;
    private bool disablePlatformerButton = false;
    private bool disableDestroyerButton = false;
    private bool disableTeleporterButton = false;
    private bool disableTimeLeaperButton = false;
    private bool disableWindMasterButton = false;
    private bool disableEvilWizardButton = false;
    private bool disableMedievalKingButton = false;
    [SerializeField] private Button StartButton;
    public Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();
    void Start()
    {
        Debug.Log("Connecting to server...");
        if(!PhotonNetwork.IsConnected) PhotonNetwork.ConnectUsingSettings();
    }
    void Update(){
        StartButton.interactable = PhotonNetwork.IsMasterClient;
    }
    public override void OnConnectedToMaster()
    {
        //reloadAnimation.SetActive(false);
        Debug.Log("Connected to master");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = PlayerNetwork.instance.username;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
        if(!PhotonNetwork.InRoom)
            GameObject.Find("UI").GetComponent<MainCanvasManager>().lobbyCanvas.transform.SetAsLastSibling();
    }
    public void StartPreventingDuplication(){
        StartCoroutine("PreventCharactersDuplication");
    }
    public void StopPreventingDuplication(){
        StopCoroutine("PreventCharactersDuplication");
    }
    private void UpdateCachedRoomList(List<RoomInfo> roomList)
    {
        Debug.Log("Update Cached Room List");
        for(int i=0; i<roomList.Count; i++)
        {
            RoomInfo info = roomList[i];
            if (info.RemovedFromList)
            {
                cachedRoomList.Remove(info.Name);
            }
            else
            {
                cachedRoomList[info.Name] = info;
            }
        }
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("On Room List Update");
        UpdateCachedRoomList(roomList);
    }
    IEnumerator PreventCharactersDuplication(){
        for(;;){
            Player[] players = PhotonNetwork.PlayerList;
            disableDestroyerButton = false;
            disablePlatformerButton = false;
            disableTeleporterButton = false;
            disableTimeLeaperButton = false;
            disableWindMasterButton = false;
            disableEvilWizardButton = false;
            disableMedievalKingButton = false;
            foreach(Player player in players){
                if((string)player.CustomProperties["Character"] == "Platformer"){
                    disablePlatformerButton = true;
                }
                if((string)player.CustomProperties["Character"] == "Destroyer"){
                    disableDestroyerButton = true;
                }
                if((string)player.CustomProperties["Character"] == "TimeLeaper"){
                    disableTimeLeaperButton = true;
                }
                if((string)player.CustomProperties["Character"] == "Teleporter"){
                    disableTeleporterButton = true;
                }
                if((string)player.CustomProperties["Character"] == "WindMaster"){
                    disableWindMasterButton = true;
                }
                if((string)player.CustomProperties["Character"] == "Swaper"){
                    disableEvilWizardButton = true;
                }
                if((string)player.CustomProperties["Character"] == "JumpKing"){
                    disableMedievalKingButton = true;
                }
            }
            platformerButton.interactable = !disablePlatformerButton;
            destroyerButton.interactable = !disableDestroyerButton;
            teleporterButton.interactable = !disableTeleporterButton;
            timeLeaperButton.interactable = !disableTimeLeaperButton;
            windMasterButton.interactable = !disableWindMasterButton;
            evilWzardButton.interactable = !disableEvilWizardButton;
            medievalKingButton.interactable = !disableMedievalKingButton;
            platformerAvatar.color = new Color(1f,1f,1f,disablePlatformerButton ? .5f : 1f);
            destroyerAvatar.color = new Color(1f,1f,1f,disableDestroyerButton ? .5f : 1f);
            teleporterAvatar.color = new Color(1f,1f,1f,disableTeleporterButton ? .5f : 1f);
            timeLeaperAvatar.color = new Color(1f,1f,1f,disableTimeLeaperButton ? .5f : 1f);
            windMasterAvatar.color = new Color(1f,1f,1f,disableWindMasterButton ? .5f : 1f);
            evilWzardAvatar.color = new Color(1f,1f,1f,disableEvilWizardButton ? .5f : 1f);
            medievalKingAvatar.color = new Color(1f,1f,1f,disableMedievalKingButton ? .5f : 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
