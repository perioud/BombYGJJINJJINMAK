using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOnOff1 : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;
    public GameObject tutorial2Area;

    public AudioSource tts;
    public AudioSource correct;

    private bool actionPerformed = false;

    void Start()
    {
        tts.Play();
        correct.Play();
        // Tutorial2area 오브젝트를 활성화합니다.
        //if (tutorial2Area != null)
        //{
        //    tutorial2Area.SetActive(true);
        //}
    }

    // 충돌 감지
    void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌했고, 아직 작업을 수행하지 않았다면
        if (other.CompareTag("Player") && !actionPerformed)
        {
            PerformAction();

            // 다음 캔버스 활성화
            Invoke("EnableNextCanvas", 2.0f);

            // 현재 캔버스 비활성화
            Invoke("DisableCanvas", 1.0f);
            correct.Play();

            actionPerformed = true;
        }
    }

    void PerformAction()
    {
        Debug.Log("퀘스트 클리어 존을 통과하였습니다..");
    }

    void EnableNextCanvas()
    {
        if (nextCanvasToShow != null)
        {
            nextCanvasToShow.SetActive(true);
        }
    }

    void DisableCanvas()
    {
        if (canvasToDisable != null)
        {
            canvasToDisable.SetActive(false);
            tutorial2Area.SetActive(false);
            //GetComponent<AudioSource>().Play();

        }
    }


}