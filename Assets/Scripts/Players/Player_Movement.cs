using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float power;
    public float delayedPower;
    private float minPower = 900f;
    private float maxPower = 4000f;
    private float powerAddingValue = 100f;
    private float multiplayer = 1.6f;
    public float horizontalAdditionalForce = 0f;
    public float verticalAdditionalForce = 0f;
    [SerializeField] private GameObject groundDetector;
    // Start is called before the first frame update
    void Start()
    {
        power = minPower;
        delayedPower = power;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space") && power < maxPower){
            power+=powerAddingValue;
            delayedPower = power;
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            if(Input.GetKeyUp("space") && groundDetector.GetComponent<Ground_Detector>().isOnThePlatform){
                rb2D.AddForce(new Vector2(transform.position.x-power+horizontalAdditionalForce,transform.position.y+power*multiplayer));
                power = minPower;
                StartCoroutine("delayPowerValue");
            }
            
        }else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            if(Input.GetKeyUp("space") && groundDetector.GetComponent<Ground_Detector>().isOnThePlatform){
                rb2D.AddForce(new Vector2(transform.position.x+power+horizontalAdditionalForce,transform.position.y+power*multiplayer));
                power = minPower;
                StartCoroutine("delayPowerValue");
            }
            
        }else{
            if(Input.GetKeyUp("space") && groundDetector.GetComponent<Ground_Detector>().isOnThePlatform){
                rb2D.AddForce(new Vector2(transform.position.x,transform.position.y+power *multiplayer));
                power = minPower;
                StartCoroutine("delayPowerValue");
            }
        }
        if(Input.GetKeyUp("space") && !groundDetector.GetComponent<Ground_Detector>().isOnThePlatform){
            power = minPower;
            StartCoroutine("delayPowerValue");
        }
    }
    IEnumerator delayPowerValue(){
        yield return new WaitForSeconds(0.8f);
        delayedPower = minPower;
    }
}
