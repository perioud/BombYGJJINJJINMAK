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
        if (GameObject.Find("MQ1") != null && GameObject.Find("MQ1").activeSelf)
        {
            audioSource.Stop();
        }
    }
}