using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SinglePlayerManager : MonoBehaviour
{
    public string playerNickname = "Player";
    public string character = "Platformer";
    [SerializeField] private GameObject platformerPrefab;
    [SerializeField] private GameObject destroyerPrefab;
    [SerializeField] private GameObject timeLeaperPrefab;
    [SerializeField] private GameObject windmasterPrefab;
    [SerializeField] private GameObject jumpkingPrefab;
    private bool spawned = false;
    void Start()
    {
        Destroy(GameObject.Find("PhotonMono"));
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game" && !spawned){
            GameObject player = Instantiate(character == "Platformer" ? 
            platformerPrefab : character == "Destroyer" ? 
            destroyerPrefab : character == "TimeLeaper" ? 
            timeLeaperPrefab : character == "WindMaster" ? 
            windmasterPrefab : jumpkingPrefab, new Vector3(-3f,-4f,0),Quaternion.identity);
            player.transform.Find("Name").gameObject.GetComponent<TextMeshPro>().text = playerNickname;
            spawned = true;
        }
    }
    public void SetNickName(Text nickname){
        playerNickname = nickname.text;
    }
    public void SetCharacter(Text text){
        character = text.text;
    }
    public void StartGame(){
        SceneManager.LoadScene("Game");
    }
}
