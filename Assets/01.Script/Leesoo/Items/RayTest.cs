using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(this.transform.position + Vector3.up, Vector3.forward * 10, Color.red);
        
        RaycastHit hitInfo;

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 30.0f))
        {
          //  Debug.Log(hitInfo.transform.name);
        }
    }   
}
