using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Animation_Controller : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject groundDetector;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.y);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.y);
        }
        if(Input.GetKey("space")){
            animator.SetInteger("state",1);
        }else{
            if(groundDetector.GetComponent<Ground_Detector>().isOnThePlatform){
                animator.SetInteger("state",0);
            }else{
                animator.SetInteger("state",2);
            }
        }
    }
}
