using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOnOff0 : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject nextCanvasToShow;

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
            Invoke("PlayAudio", (delayTime - 1.0f)); // 1�� �ڿ� ����� ���
        }
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            PerformAction();
            actionPerformed = true;
            Invoke("DisableCanvas", delayTime);
            Invoke("PlayAudio", (delayTime - 1.0f)); // 1�� �ڿ� ����� ���
        }
    }

    void PerformAction()
    {
        Debug.Log("���� Ȱ��ȭ ����");
    }

    void DisableCanvas()
    {
        if (actionPerformed && canvasToDisable != null)
        {
            canvasToDisable.SetActive(false);

            // 1�� �ڿ� �ٸ� Canvas�� Ȱ��ȭ�մϴ�.
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
        correct.Play();
    }
}