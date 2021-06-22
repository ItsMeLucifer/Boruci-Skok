using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfSingleBlockSpectatorMode : MonoBehaviour
{
    private GameObject singlePlayerManager;
    [SerializeField] private GameObject startSpectatorButton;
    [SerializeField] private GameObject stopSpectatorButton;
    void Start()
    {
        if(GameObject.Find("SinglePlayerManager") != null){
            Destroy(startSpectatorButton);
            Destroy(stopSpectatorButton);
        }
    }
}
