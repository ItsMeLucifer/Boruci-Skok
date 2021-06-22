using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetSpectateModeTarget : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = GameObject.Find("Main Camera").GetComponent<CameraScript>().cameraTarget.name;
    }
}
