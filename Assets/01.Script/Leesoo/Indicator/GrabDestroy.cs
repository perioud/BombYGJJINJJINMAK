using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDestroy : MonoBehaviour
{
    public GameObject Tr;
    public GameObject DelArrow;

    // Update is called once per frame
    void Update()
    {
        if (Tr.transform.GetComponent<Rigidbody>().isKinematic == true)
        {
            DelArrow.SetActive(false);
        }
    }
}
