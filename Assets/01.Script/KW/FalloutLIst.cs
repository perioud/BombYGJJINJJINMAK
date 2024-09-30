using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutLIst : MonoBehaviour
{
    public GameObject OffUI;
    public GameObject OnUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OffUI.activeSelf)
        {
            Debug.Log("ddd");
            OnUI.SetActive(true);
        }
    }
}
