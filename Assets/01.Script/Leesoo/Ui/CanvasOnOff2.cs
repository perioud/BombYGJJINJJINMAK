using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOnOff2 : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;
    public GameObject videoPlayer; // Video Player 오브젝트 추가

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
        // Video Player 오브젝트가 활성화되었는지 확인
        bool videoPlayerActive = videoPlayer != null && videoPlayer.activeSelf;

        // Video Player가 활성화되면 다음 캔버스를 활성화
        if (videoPlayerActive)
        {
            PerformAction();
            Invoke("DisableCanvas", 0.1f);
            actionPerformed = true;
        }
        // Video Player가 비활성화되면 일반적인 동작 수행
        else
        {

        }
    }

    void PerformAction()
    {
        Debug.Log("TV 실행이 감지되었습니다.");
    }

    void DisableCanvas()
    {
        if (actionPerformed && canvasToDisable != null)
        {
            canvasToDisable.SetActive(false);

            // 1초 뒤에 다른 Canvas를 활성화합니다.
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