using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOnOff : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;
    public GameObject triggerObject;

    public float delayTime = 10f;

    private bool actionPerformed = false;
    public AudioSource tts;
    public AudioSource correct;

    void Start()
    {
        tts.Play();
        // 버튼 클릭 이벤트에 대한 리스너를 추가합니다.
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void PerformAction()
    {
        Debug.Log("버튼 클릭 감지");
    }

    void DisableCanvas()
    {
        if (actionPerformed && canvasToDisable != null)
        {
            canvasToDisable.SetActive(false);

            // 1초 뒤에 다음 Canvas를 활성화합니다.
            Invoke("EnableNextCanvas", 0.5f);
        }
    }

    void EnableNextCanvas()
    {
        if (nextCanvasToShow != null)
        {

            nextCanvasToShow.SetActive(true);
            triggerObject.SetActive(true);

        }
    }

    void OnButtonClick()
    {
        PerformAction(); // 버튼 클릭 감지
        actionPerformed = true;
        DisableCanvas(); // 현재 캔버스 비활성화 및 다음 캔버스 활성화
        //GetComponent<AudioSource>().Play();
    }


}