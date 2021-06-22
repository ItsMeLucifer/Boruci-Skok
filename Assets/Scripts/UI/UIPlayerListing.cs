using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class UIPlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField] private Sprite huntressAvatar;
    [SerializeField] private Sprite wizardAvatar;
    [SerializeField] private Sprite martialistAvatar;
    [SerializeField] private Sprite warriorAvatar;
    [SerializeField] private Sprite samuraiAvatar;
    [SerializeField] private Sprite evilWzardAvatar;
    [SerializeField] private Sprite medievalKingAvatar;
    [SerializeField] private Text username;
    [SerializeField] private Text ultimatesText;
    [SerializeField] private GameObject avatar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetInfo(Player photonPlayer){
        if(photonPlayer.CustomProperties["Character"] != null){
            avatar.GetComponent<Image>().sprite = chooseSprite(photonPlayer.CustomProperties["Character"].ToString());
            username.text = photonPlayer.NickName.ToString();
            if((string)photonPlayer.CustomProperties["Character"] != "JumpKing" && photonPlayer.CustomProperties["Ultimates"] != null){
                ultimatesText.text = "Ult's: "+photonPlayer.CustomProperties["Ultimates"].ToString();
            }else{
                ultimatesText.text = "No Ultimate";
            }
        }
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
        return huntressAvatar;
    }
}
