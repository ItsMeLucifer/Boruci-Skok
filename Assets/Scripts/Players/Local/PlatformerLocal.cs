using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerLocal : MonoBehaviour
{
    public bool ultimate = false;
    private int amountOfUltimates = 3;
    private GameObject platformSemiTransparentGraph;
    [SerializeField] private GameObject platformPrefab;
    // Start is called before the first frame update
    void Start()
    {
        platformSemiTransparentGraph = GameObject.Find("PlatformSemitransparentGraph");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && amountOfUltimates > 0){
            ultimate = true;
        }
        if(ultimate){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            platformSemiTransparentGraph.transform.position = (Vector3)mousePosition;
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                Instantiate(platformPrefab, mousePosition, Quaternion.identity);
                platformSemiTransparentGraph.transform.position = new Vector3(-9f,-6f,0);
                amountOfUltimates--;
                ultimate = false;
            }
            if(Input.GetKeyDown(KeyCode.Mouse1)){
                platformSemiTransparentGraph.transform.position = new Vector3(-9f,-6f,0);
                ultimate = false;
            }
        }
    }
}
