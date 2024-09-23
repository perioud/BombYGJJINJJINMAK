using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSound : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    public GameObject Object7;
    public GameObject Object8;
    public GameObject Object9;
    public GameObject Object10;
    public GameObject Object11;
    public GameObject Object12;
    public GameObject Object13;
    public GameObject Object14;
    public GameObject Object15;
    public GameObject Object16;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!Object1.activeSelf || !Object2.activeSelf || !Object3.activeSelf || !Object4.activeSelf || !Object5.activeSelf
            || !Object6.activeSelf || !Object7.activeSelf || !Object8.activeSelf || !Object9.activeSelf || !Object10.activeSelf
            || !Object11.activeSelf || !Object12.activeSelf || !Object13.activeSelf || !Object14.activeSelf || !Object15.activeSelf || !Object16.activeSelf)
        {
            audioSource.Play();
        }
    }
}
