using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject StartSpectatorModeButton;
    [SerializeField] private GameObject StopSpectatorModeButton;
    public void ChangeSpectatorModeButtonsVisibility(){
        StartSpectatorModeButton.SetActive(!StartSpectatorModeButton.activeSelf);
        StopSpectatorModeButton.SetActive(!StopSpectatorModeButton.activeSelf);
    }
}
