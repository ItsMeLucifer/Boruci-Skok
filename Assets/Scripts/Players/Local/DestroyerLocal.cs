using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerLocal : MonoBehaviour
{
    public bool ultimate = false;
    private int amountOfUltimates = 5;
    [SerializeField] private GameObject blackoutPrefab;
    private GameObject blackout;
    // Start is called before the first frame update
    void Start()
    {
            blackout = Instantiate(blackoutPrefab,new Vector3(0,0,0), Quaternion.identity);
            blackout.GetComponent<AlwaysInTheSamePosition>().objectToPin = GameObject.Find("Main Camera");
            blackout.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && amountOfUltimates > 0){
            ultimate = true;
            blackout.SetActive(true);
        }
        if(ultimate){
            if(Input.GetMouseButton(0)){
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero);
                if(hit.collider != null && (hit.collider.gameObject.tag == "Platform" || hit.collider.gameObject.tag == "MovingPlatform")){
                    Destroy(hit.collider.gameObject);
                    amountOfUltimates--;
                    blackout.SetActive(false);
                    ultimate = false;
                }
            }else if(Input.GetMouseButton(1)){
                blackout.SetActive(false);
                ultimate = false;
            }
        }
    }
}
