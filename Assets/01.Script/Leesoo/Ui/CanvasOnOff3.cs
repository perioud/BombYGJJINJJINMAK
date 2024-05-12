using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOnOff3 : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;

    //public float delayTime = 3f;

    //private bool actionPerformed = false;

    //public AudioSource tts;
    public AudioSource nuc;
    public AudioSource tts;
    public AudioSource correct;

    void Start()
    {
        tts.Play();
        correct.Play();
        // 10�� �Ŀ� nuc ������� ���
        Invoke("PlayAudio", 10.0f);
        Invoke("EnableNextCanvas", 10.0f);
    }

    void PlayAudio()
    {
        //correct.Play();
        nuc.Play();
        //isPlaying = true;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        PerformAction();
    //        actionPerformed = true;
    //        Invoke("DisableCanvas", delayTime);
    //    }
    //}

    //void PerformAction()
    //{
    //    Debug.Log("������ �̵��մϴ�.");
    //}

    //void DisableCanvas()
    //{
    //    if (actionPerformed && canvasToDisable != null)
    //    {
    //        canvasToDisable.SetActive(false);

    //        // 1�� �ڿ� �ٸ� Canvas�� Ȱ��ȭ�մϴ�.
    //        Invoke("EnableNextCanvas", 1f);
    //    }
    //}

    void EnableNextCanvas()
    {
        if (nextCanvasToShow != null)
        {
            nextCanvasToShow.SetActive(true);
        }
    }
}