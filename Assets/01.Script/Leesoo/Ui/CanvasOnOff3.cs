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
        // 10초 후에 nuc 오디오를 재생
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
    //    Debug.Log("앞으로 이동합니다.");
    //}

    //void DisableCanvas()
    //{
    //    if (actionPerformed && canvasToDisable != null)
    //    {
    //        canvasToDisable.SetActive(false);

    //        // 1초 뒤에 다른 Canvas를 활성화합니다.
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