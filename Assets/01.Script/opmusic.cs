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
        // Quest1 ������Ʈ�� Ȱ��ȭ�Ǹ� ������ ����ϴ�.
        if (GameObject.Find("Tutorial3") != null && GameObject.Find("Tutorial3").activeSelf)
        {
            audioSource.Stop();
        }
    }
}