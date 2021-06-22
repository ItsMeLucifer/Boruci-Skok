using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviourPunCallbacks
{
    private GameObject[] players;
    [SerializeField] private GameObject UI;
    private bool multiplayer = true;
    public List<GameObject> playersEndedGame = new List<GameObject>();
    void Start()
    {
        UI.SetActive(false);
        multiplayer = GameObject.Find("SinglePlayerManager") == null;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            UI.SetActive(!UI.activeSelf);
        }
        if(multiplayer && playersEndedGame.Count == GameObject.FindGameObjectsWithTag("Player").Length){
            SceneManager.LoadScene("End");
        }
        if(SceneManager.GetActiveScene().name == "End" && Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("Menu");
        }
    }
    public void closeUI(){
        UI.SetActive(false);
    }
}
