using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore_Collisions : MonoBehaviour
{
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i< players.Length-1;i++){
            for(int j = i+1;j<players.Length;j++){
                Physics2D.IgnoreCollision(players[i].GetComponent<BoxCollider2D>(),players[j].GetComponent<BoxCollider2D>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
