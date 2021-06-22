using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class Platformer : MonoBehaviourPunCallbacks
{
    public bool ultimate = false;
    private int amountOfUltimates = 5;
    private GameObject platformSemiTransparentGraph; 
    // Start is called before the first frame update
    void Start()
    {
        platformSemiTransparentGraph = GameObject.Find("PlatformSemitransparentGraph");
        if(GetComponent<PhotonView>().IsMine){
            SetProperties();
            photonView.RPC("UpdateUIPlayersInfo", RpcTarget.All);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PhotonView>().IsMine && Input.GetKeyDown(KeyCode.R) && amountOfUltimates > 0 && !GetComponent<SpectatorMode>().start){
            ultimate = true;
        }
        if(ultimate){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            platformSemiTransparentGraph.transform.position = (Vector3)mousePosition;
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                PhotonNetwork.Instantiate("Platform", mousePosition, Quaternion.identity);
                platformSemiTransparentGraph.transform.position = new Vector3(-9f,-6f,0);
                amountOfUltimates--;
                SetProperties();
                photonView.RPC("UpdateUIPlayersInfo", RpcTarget.All);
                ultimate = false;
            }
            if(Input.GetKeyDown(KeyCode.Mouse1)){
                platformSemiTransparentGraph.transform.position = new Vector3(-9f,-6f,0);
                ultimate = false;
            }
        }
    }
    private void SetProperties(){
        Hashtable hash = new Hashtable();
        hash.Add("Ultimates", amountOfUltimates);
        hash.Add("Character", "Platformer");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}
