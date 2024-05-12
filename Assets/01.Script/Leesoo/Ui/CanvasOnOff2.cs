using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOnOff2 : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;
    public GameObject videoPlayer; // Video Player ������Ʈ �߰�

    public OVRInput.Controller controller;

    //bool isPlaying = false;

    public float delayTime = 30f;

    private bool actionPerformed = false;

    public AudioSource tts;

    void Start()
    {
        tts.Play();
    }

    void Update()
    {
        // Video Player ������Ʈ�� Ȱ��ȭ�Ǿ����� Ȯ��
        bool videoPlayerActive = videoPlayer != null && videoPlayer.activeSelf;

        // Video Player�� Ȱ��ȭ�Ǹ� ���� ĵ������ Ȱ��ȭ
        if (videoPlayerActive)
        {
            PerformAction();
            Invoke("DisableCanvas", 0.1f);
            actionPerformed = true;
        }
        // Video Player�� ��Ȱ��ȭ�Ǹ� �Ϲ����� ���� ����
        else
        {

        }
    }

    void PerformAction()
    {
        Debug.Log("TV ������ �����Ǿ����ϴ�.");
    }

    void DisableCanvas()
    {
        if (actionPerformed && canvasToDisable != null)
        {
            canvasToDisable.SetActive(false);

            // 1�� �ڿ� �ٸ� Canvas�� Ȱ��ȭ�մϴ�.
            Invoke("EnableNextCanvas", 0.1f);
        }
    }

    void EnableNextCanvas()
    {
        if (nextCanvasToShow != null)
        {
            nextCanvasToShow.SetActive(true);
        }
    }

}