using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;


    void Update()
    {
        if (!Object1.activeSelf)
        {
            Object2.SetActive(true);
            Object3.SetActive(true);
        }
    }
}
