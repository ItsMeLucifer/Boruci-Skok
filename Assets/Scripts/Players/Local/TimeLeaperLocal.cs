using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimeLeaperLocal : MonoBehaviour
{
    private int amountOfUltimates = 2;
    [SerializeField] private GameObject prefab;
    private GameObject mount;
    private List<Vector3> positions = new List<Vector3>();
    private int count = 0;
    void Start()
    {
        mount = Instantiate(prefab, transform.position, Quaternion.identity);
        mount.GetComponent<MountScript>().destination = transform.position;
        StartCoroutine("GetPosition");
        StartCoroutine("SetMountPosition");
    }

    IEnumerator GetPosition(){
        for(;;){
            positions.Add(transform.position);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator SetMountPosition(){
        yield return new WaitForSeconds(3f);
        for(;;){
            mount.GetComponent<MountScript>().destination = positions[count];
            count++;
            yield return new WaitForSeconds(0.5f); 
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && amountOfUltimates > 0){
            transform.position = new Vector3(mount.transform.position.x,mount.transform.position.y+0.5f,0f);
            amountOfUltimates--;
            if(amountOfUltimates <= 0){
                StopCoroutine("GetPosition");
                StopCoroutine("SetMountPosition");
                Destroy(mount);
            }
        }
    }
}
