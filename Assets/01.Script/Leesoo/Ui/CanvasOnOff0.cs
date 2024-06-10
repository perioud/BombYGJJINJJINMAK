using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOnOff0 : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;
    public Outline outlineToCheck;
    public float delayTime = 2.0f;
    public AudioSource cur;

    private bool actionPerformed = false;

    void Update()
    {
        // 아웃라인이 활성화되었는지 체크합니다.
        if (outlineToCheck != null && outlineToCheck.enabled && !actionPerformed)
        {
            PerformAction();
            actionPerformed = true;
            Invoke("DisableCanvas", delayTime);
            Invoke("PlayAudio", (delayTime - 1.9f)); // 1초 뒤에 오디오 재생
        }
    }

    void PerformAction()
    {
        Debug.Log("레이 활성화 감지");
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
        // 오디오 재생 로직을 여기에 추가하십시오.
    }
}
