using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextArrow : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;
    public GameObject nextArrow;

    public float delayTime = 2.0f;

    private bool actionPerformed = false;

    public AudioSource tts;
    public AudioSource correct;
    void Start()
    {
        tts.Play();
    }


    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            PerformAction();
            actionPerformed = true;
            Invoke("DisableCanvas", delayTime);
            Invoke("PlayAudio", (delayTime - 1.0f)); // 1초 뒤에 오디오 재생
        }
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            PerformAction();
            actionPerformed = true;
            Invoke("DisableCanvas", delayTime);
            Invoke("PlayAudio", (delayTime - 1.0f)); // 1초 뒤에 오디오 재생
        }
    }

    void PerformAction()
    {
        Debug.Log("레이 활성화 감지");
    }

    void DisableCanvas()
    {
        if (actionPerformed && canvasToDisable && nextArrow != null)
        {
            canvasToDisable.SetActive(false);

            // 1초 뒤에 다른 Canvas를 활성화합니다.
            Invoke("EnableNextCanvas", 1f);
            NextArrowShow();
        }
    }

    void EnableNextCanvas()
    {
        if (nextCanvasToShow != null)
        {
            nextCanvasToShow.SetActive(true);
        }
    }

    void NextArrowShow()
    {
        if (nextArrow != null)
        {
            nextArrow.SetActive(true);
        }
    }

}
