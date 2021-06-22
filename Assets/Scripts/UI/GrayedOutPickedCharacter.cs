using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrayedOutPickedCharacter : MonoBehaviour
{
    private GameObject singlePlayerManager;
    [SerializeField] private Image avatar;
    private Button button;
    [SerializeField] private Text characterText;
    void Start()
    {
        singlePlayerManager = GameObject.Find("SinglePlayerManager");
        button = GetComponent<Button>();
    }
    void Update()
    {
        button.interactable = !(singlePlayerManager.GetComponent<SinglePlayerManager>().character == characterText.text);
        avatar.color = new Color(1f,1f,1f,singlePlayerManager.GetComponent<SinglePlayerManager>().character == characterText.text ? .5f : 1f);
    }
}
