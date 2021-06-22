using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), col.collider);
            Physics2D.IgnoreCollision(transform.GetChild(1).GetComponent<PolygonCollider2D>(), col.collider);
        }
    }
}
