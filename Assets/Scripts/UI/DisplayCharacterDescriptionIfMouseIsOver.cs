using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCharacterDescriptionIfMouseIsOver : MonoBehaviour
{
    [SerializeField] private GameObject description;
    void Start(){
        description.SetActive(false);
    }
    void OnMouseEnter(){
        description.SetActive(true);
    }
    void OnMouseExit(){
        description.SetActive(false);
    }
}
