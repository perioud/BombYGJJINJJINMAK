using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CanvasOnOff2 : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;
    public GameObject videoPlayer; // Video Player 오브젝트 추가
    public GameObject[] imagesToDisable;
    public OVRInput.Controller controller;
    public float delayTime = 30f;
    private bool actionPerformed = false;
    private bool ttsPlayed = false;
    private bool tts2Played = false;
    private bool correctPlayed = false;
    public GameObject bomb;
    public GameObject SeeTarget;
    public AudioSource tts;
    public AudioSource tts2;
    public AudioSource correct;

    void Start()
    {

        if (!ttsPlayed)
        {
            tts.Play();
            ttsPlayed = true;
        }
    }

    void Update()
    {
        // Video Player 오브젝트가 활성화되었는지 확인
        bool videoPlayerActive = videoPlayer != null && videoPlayer.activeSelf;

        // Video Player가 활성화되면 다음 캔버스를 활성화
        if (videoPlayerActive && !actionPerformed)
        {
            if (tts.isPlaying)
            {
                tts.Stop();
            }

            PerformAction();
            Invoke("ActivateBomb", 20f);
            actionPerformed = true;
            Invoke("Disable", 22f);

            if (!tts2Played)
            {
                tts2.Play();
                tts2Played = true;
            }

            if (!correctPlayed)
            {
                correct.Play();
                correctPlayed = true;
            }

            foreach (GameObject image in imagesToDisable)
            {
                if (image != null)
                {
                    image.SetActive(false);
                    Debug.Log("UI이미지 비활성화");
                }
            }
        }
    }

    void ActivateBomb()
    {
        if (bomb != null)
        {
            bomb.SetActive(true);
            Debug.Log("Bomb 활성화");
            Invoke("EnableNextCanvas", 3f);
        }
        SeeTarget.SetActive(true);
    }

    void PerformAction()
    {
        Debug.Log("TV 실행이 감지되었습니다.");
    }

    void Disable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.SetActive(false);
            Debug.Log("Tv 비활성화");
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
