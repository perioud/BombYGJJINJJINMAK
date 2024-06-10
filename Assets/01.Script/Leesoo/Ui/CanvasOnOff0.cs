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
        // �ƿ������� Ȱ��ȭ�Ǿ����� üũ�մϴ�.
        if (outlineToCheck != null && outlineToCheck.enabled && !actionPerformed)
        {
            PerformAction();
            actionPerformed = true;
            Invoke("DisableCanvas", delayTime);
            Invoke("PlayAudio", (delayTime - 1.9f)); // 1�� �ڿ� ����� ���
        }
    }

    void PerformAction()
    {
        Debug.Log("���� Ȱ��ȭ ����");
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
        // ����� ��� ������ ���⿡ �߰��Ͻʽÿ�.
    }
}
