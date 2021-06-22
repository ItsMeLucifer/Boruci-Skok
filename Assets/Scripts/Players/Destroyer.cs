using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class Destroyer : MonoBehaviourPunCallbacks
{
    public bool ultimate = false;
    private int amountOfUltimates = 10;
    [SerializeField] private GameObject blackoutPrefab;
    private GameObject blackout;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<PhotonView>().IsMine){
            blackout = Instantiate(blackoutPrefab,new Vector3(0,0,0), Quaternion.identity);
            blackout.GetComponent<AlwaysInTheSamePosition>().objectToPin = GameObject.Find("Main Camera");
            blackout.SetActive(false);
            SetProperties();
            GetComponent<PhotonView>().RPC("UpdateUIPlayersInfo", RpcTarget.All);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PhotonView>().IsMine && Input.GetKeyDown(KeyCode.R) && amountOfUltimates > 0 && !GetComponent<SpectatorMode>().start){
            ultimate = true;
            blackout.SetActive(true);
        }
        if(ultimate){
            if(Input.GetMouseButton(0)){
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero);
                if(hit.collider != null && (hit.collider.gameObject.tag == "Platform" || hit.collider.gameObject.tag == "MovingPlatform")){
                    //PhotonNetwork.Destroy(hit.collider.gameObject);
                    GetComponent<PhotonView>().RPC("DestroyPlatform",RpcTarget.All,hit.collider.gameObject.name);
                    amountOfUltimates--;
                    blackout.SetActive(false);
                    SetProperties();
                    GetComponent<PhotonView>().RPC("UpdateUIPlayersInfo", RpcTarget.All);
                    ultimate = false;
                }
            }else if(Input.GetMouseButton(1)){
                blackout.SetActive(false);
                ultimate = false;
            }
        }
    }
    private void SetProperties(){
        Hashtable hash = new Hashtable();
        hash.Add("Ultimates", amountOfUltimates);
        hash.Add("Character", "Destroyer");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}
