using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opmusic : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        // Quest1 오브젝트가 활성화되면 음악을 멈춥니다.
        if (GameObject.Find("NukeQuest") != null && GameObject.Find("NukeQuest").activeSelf)
        {
            audioSource.Stop();
        }
    }
}