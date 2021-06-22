using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerListing : MonoBehaviourPunCallbacks
{
    public Player photonPlayer { get; private set; }
    [SerializeField] private Image avatar;
    [SerializeField] private Sprite huntressAvatar;
    [SerializeField] private Sprite wizardAvatar;
    [SerializeField] private Sprite martialistAvatar;
    [SerializeField] private Sprite warriorAvatar;
    [SerializeField] private Sprite samuraiAvatar;
    [SerializeField] private Sprite evilWzardAvatar;
    [SerializeField] private Sprite medievalKingAvatar;
    [SerializeField] private Sprite transparentAvatar;
    [SerializeField] private Image crownIcon;
    [SerializeField]
    private Text _playerName;
    public Text playerName
    {
        get { return _playerName; }
    }
    [SerializeField]
    private Text _character;
    public Text character
    {
        get { return _character; }
    }
    public void ApplyPhotonPlayer(Player photonPlayer)
    {
        if(photonPlayer != null){
            this.photonPlayer = photonPlayer;
            _playerName.text = photonPlayer.NickName;
            _character.text = (string)photonPlayer.CustomProperties["Character"];
            avatar.sprite = chooseSprite(_character.text);
        }
    }
    void Update(){
        crownIcon.enabled = photonPlayer.IsMasterClient;
    }
    Sprite chooseSprite(string characterName){
        if(characterName == "Platformer")
            return huntressAvatar;
        if(characterName == "Teleporter")
            return wizardAvatar;
        if(characterName == "TimeLeaper")
            return martialistAvatar;
        if(characterName == "Destroyer")
            return warriorAvatar;
        if(characterName == "WindMaster")
            return samuraiAvatar;
        if(characterName == "Swaper")
            return evilWzardAvatar;
        if(characterName == "JumpKing")
            return medievalKingAvatar;
        return transparentAvatar;
    }
}
