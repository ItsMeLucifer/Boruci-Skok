using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class PlayerNetwork : MonoBehaviourPunCallbacks
{
    public static PlayerNetwork instance;
    public string username { get; private set; }
    private GameObject test;
    private string character;
    private bool canSpawnCharacter = true;
    [SerializeField] private Text usernameInputFieldText;
    private void Awake()
    {
        instance = this;
        username = "Gracz#" + Random.Range(1000, 9999);
        character = "";
        Hashtable hash = new Hashtable();
        hash.Add("Character", "");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
    void Start(){
        if(SceneManager.GetActiveScene().name == "Lobby" && GameObject.Find("userNameInputField").GetComponent<InputField>().text == "") GameObject.Find("userNameInputField").GetComponent<InputField>().text = PhotonNetwork.LocalPlayer.NickName;
        if(username != usernameInputFieldText.text){
            ChangeNickname(usernameInputFieldText);
        }
    }
    public void ChangeNickname(Text nickname)
    {
        username = nickname.text;
        PhotonNetwork.NickName = username;
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected");
        SceneManager.LoadScene("Menu");
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game" && canSpawnCharacter)
        {
            CreatePlayer();
            canSpawnCharacter = false;
        }
        
    }
    public void DisconnectPlayer(){
        PhotonNetwork.Disconnect();
    }
    public void chooseCharacter(Text character){
        if(character.text != ""){
            this.character = character.text;
            Hashtable hash = new Hashtable();
            hash.Add("Character", character.text);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }
    private void CreatePlayer()
    {
        float randomX = Random.Range(-6f, 2f);
        float randomY = -4f;
        GameObject g = PhotonNetwork.Instantiate(character, new Vector3(randomX, randomY, 0), Quaternion.identity);
        g.name = username;
    }
    
}