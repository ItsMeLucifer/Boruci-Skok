using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class TimeLeaper : MonoBehaviourPunCallbacks
{
    private int amountOfUltimates = 10;
    [SerializeField] private GameObject prefab;
    private GameObject mount;
    private List<Vector3> positions = new List<Vector3>();
    private int count = 0;
    void Start()
    {
        if(GetComponent<PhotonView>().IsMine){
            mount = Instantiate(prefab, transform.position, Quaternion.identity);
            mount.GetComponent<MountScript>().destination = transform.position;
            SetProperties();
            photonView.RPC("UpdateUIPlayersInfo", RpcTarget.All);
            StartCoroutine("GetPosition");
            StartCoroutine("SetMountPosition");
        }
    }

    IEnumerator GetPosition(){
        for(;;){
            positions.Add(transform.position);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator SetMountPosition(){
        yield return new WaitForSeconds(3f);
        for(;;){
            mount.GetComponent<MountScript>().destination = positions[count];
            count++;
            yield return new WaitForSeconds(0.5f); 
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && GetComponent<PhotonView>().IsMine && amountOfUltimates > 0 && !GetComponent<SpectatorMode>().start){
            transform.position = new Vector3(mount.transform.position.x,mount.transform.position.y+0.5f,0f);
            amountOfUltimates--;
            SetProperties();
            photonView.RPC("UpdateUIPlayersInfo", RpcTarget.All);
            if(amountOfUltimates <= 0){
                StopCoroutine("GetPosition");
                StopCoroutine("SetMountPosition");
                Destroy(mount);
            }
        }
    }
    private void SetProperties(){
        Hashtable hash = new Hashtable();
        hash.Add("Ultimates", amountOfUltimates);
        hash.Add("Character", "TimeLeaper");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}
