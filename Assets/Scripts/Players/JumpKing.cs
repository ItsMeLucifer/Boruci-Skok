using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKing : MonoBehaviour
{
    [SerializeField] private GameObject jumpForceBar;
    [SerializeField] private SpriteRenderer barColor;
    private GameObject jumpBar;
    private float proportion = 1f;
    void Start(){
        jumpBar = transform.Find("JumpBar").gameObject;
        jumpBar.SetActive(false);
    }
    void Update()
    {
        if(!jumpBar.activeSelf) jumpBar.SetActive(true);
        barColor.color = setColor((GetComponent<Player_Movement>().delayedPower - 900f ) / 3100f);
        proportion = (GetComponent<Player_Movement>().delayedPower - 900f ) / 3100f;
        jumpForceBar.transform.localScale = new Vector3(proportion,1f,1f);
    }
    Color setColor(float power){
        if(power <0.4f){
            return new Color(0.17f,0.59f,0.42f,1f);
        }
        if(power <0.65f){
            return new Color(0.76f,0.76f,0.2f,1f);
        }
        if(power <0.95f){
            return new Color(0.83f,0.36f,0f,1f);
        }
        return new Color(0.83f,0f,0.16f,1f);
    }
}
