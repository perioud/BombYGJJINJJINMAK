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
        // Quest1 ������Ʈ�� Ȱ��ȭ�Ǹ� ������ ����ϴ�.
        if (GameObject.Find("NukeQuest") != null && GameObject.Find("NukeQuest").activeSelf)
        {
            audioSource.Stop();
        }
    }
}