using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opmusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        // Quest1 오브젝트가 활성화되면 음악을 멈춥니다.
        if (GameObject.Find("MQ1") != null && GameObject.Find("MQ1").activeSelf)
        {
            audioSource.Stop();
        }
    }
}