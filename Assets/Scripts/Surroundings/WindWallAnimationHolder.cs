using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWallAnimationHolder : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("windAnimation");
    }

    IEnumerator windAnimation(){
        for(int i = 0; i< transform.childCount;i++){
            transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("start",true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
