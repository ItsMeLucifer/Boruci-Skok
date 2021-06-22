using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HostGameButton : MonoBehaviour
{
    public Text usernameInputText;
    public Text roomNameInputText;
    private GameObject hostButtonText;
    void Start()
    {
        hostButtonText = gameObject.transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (usernameInputText.GetComponent<Text>().text == "" || roomNameInputText.GetComponent<Text>().text == "")
        {
            gameObject.GetComponent<Button>().interactable = false;
            //hostButtonText.GetComponent<Text>().color = new Color(0.67f, 0.67f, 0.67f);
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            //hostButtonText.GetComponent<Text>().color = new Color(255f, 255f, 255f);
        }
    }
}
