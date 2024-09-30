using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiOnOff : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject OffUI;
    public GameObject OnUI;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!Object1.activeSelf && !Object2.activeSelf && !Object3.activeSelf && !Object4.activeSelf && !Object5.activeSelf)
        {
            audioSource.Play();
            OffUI.SetActive(false);
            OnUI.SetActive(true);
        }
    }
}
