using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    private bool state;
    public GameObject phone;

    void Start()
    {
        state = true;
    }

    void Update()
    {
        TogglePhone();
    }

    void TogglePhone()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (state == true)
            {
                Debug.Log("²¨Áü");
                GameObject.Find("Phone").transform.GetChild(0).gameObject.SetActive(false);
                //GameObject.Find("iphone").transform.GetChild(0).gameObject.SetActive(false);
                //phone.SetActive(false);
                state = false;
            }
            else
            {
                Debug.Log("ÄÑÁü");
                GameObject.Find("Phone").transform.GetChild(0).gameObject.SetActive(true);
                //GameObject.Find("iphone").transform.GetChild(0).gameObject.SetActive(false);
                //phone.SetActive(true);
                state = true;
            }
        }
    }
}

