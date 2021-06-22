using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class WindMaster : MonoBehaviour
{
    private int amountOfUltimates = 7;
    [SerializeField] private GameObject gravityMask;
    private GameObject singlePlayerManager;
    private bool canStartUltimate = true;
    // Start is called before the first frame update
    void Start()
    {
        singlePlayerManager = GameObject.Find("SinglePlayerManager");
        if(singlePlayerManager == null && GetComponent<PhotonView>().IsMine){
            SetProperties();
            GetComponent<PhotonView>().RPC("UpdateUIPlayersInfo", RpcTarget.All);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && amountOfUltimates > 0 && canStartUltimate && !GetComponent<SpectatorMode>().start){
            StartCoroutine("ChangeMassOfPlayers");
        }
    }
    IEnumerator ChangeMassOfPlayers(){
        canStartUltimate = false;
        GetComponent<Rigidbody2D>().mass = 7f;
        GameObject g = Instantiate(gravityMask,new Vector3(0,0,0),Quaternion.identity);
        g.transform.SetParent(GameObject.Find("UI").transform);
        for(int i = 0;i<10;i++){
            if(i==9){
                GetComponent<Rigidbody2D>().mass = 10f;
                Destroy(g);
                amountOfUltimates--;
                SetProperties();
                canStartUltimate = true;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private void SetProperties(){
        Hashtable hash = new Hashtable();
        hash.Add("Ultimates", amountOfUltimates);
        hash.Add("Character", "WindMaster");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}
