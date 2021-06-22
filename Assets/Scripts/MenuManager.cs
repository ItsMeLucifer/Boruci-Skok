using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("DDOL"));
        //Destroy(GameObject.Find("PhotonMono"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
