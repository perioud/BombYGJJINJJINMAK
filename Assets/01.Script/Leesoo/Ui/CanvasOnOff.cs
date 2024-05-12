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
        // ��ư Ŭ�� �̺�Ʈ�� ���� �����ʸ� �߰��մϴ�.
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void PerformAction()
    {
        Debug.Log("��ư Ŭ�� ����");
    }

    void DisableCanvas()
    {
        if (actionPerformed && canvasToDisable != null)
        {
            canvasToDisable.SetActive(false);

            // 1�� �ڿ� ���� Canvas�� Ȱ��ȭ�մϴ�.
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
        PerformAction(); // ��ư Ŭ�� ����
        actionPerformed = true;
        DisableCanvas(); // ���� ĵ���� ��Ȱ��ȭ �� ���� ĵ���� Ȱ��ȭ
        //GetComponent<AudioSource>().Play();
    }


}