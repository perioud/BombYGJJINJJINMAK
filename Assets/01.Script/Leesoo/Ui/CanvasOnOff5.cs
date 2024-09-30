using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CanvasOnOff5 : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;
    public OVRInput.Controller controller;
    public AudioSource cur;

    private IActiveState ActiveState { get; set; }
    private bool actionPerformed = false; // 액션이 수행되었는지 확인하는 플래그



    void Start()
    {
        ActiveState = FindObjectOfType<InteractorActiveState>();

    }

    void Update()
    {
        PerformAction();

    }

    void PerformAction()
    {

        bool isActive = ActiveState.Active;

        if (isActive && !actionPerformed)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
            {
                actionPerformed = true; // 플래그를 true로 설정하여 다시 실행되지 않도록 함
                Invoke("DisableCanvas", 1.5f);
                Invoke("PlayAudio", 0.1f);
            }

        }
    }

    void DisableCanvas()
    {
        if (canvasToDisable != null)
        {
            canvasToDisable.SetActive(false);
            // 1초 뒤에 다른 Canvas를 활성화합니다.
            Invoke("EnableNextCanvas", 1f);
        }
    }

    void EnableNextCanvas()
    {
        if (nextCanvasToShow != null)
        {
            nextCanvasToShow.SetActive(true);
        }
    }

    void PlayAudio()
    {
        cur.Play();
    }
}
