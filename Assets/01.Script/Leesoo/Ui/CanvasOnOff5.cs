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
    private bool actionPerformed = false; // �׼��� ����Ǿ����� Ȯ���ϴ� �÷���



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
                actionPerformed = true; // �÷��׸� true�� �����Ͽ� �ٽ� ������� �ʵ��� ��
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
        cur.Play();
    }
}
