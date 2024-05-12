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
        // Tutorial2area ������Ʈ�� Ȱ��ȭ�մϴ�.
        //if (tutorial2Area != null)
        //{
        //    tutorial2Area.SetActive(true);
        //}
    }

    // �浹 ����
    void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹�߰�, ���� �۾��� �������� �ʾҴٸ�
        if (other.CompareTag("Player") && !actionPerformed)
        {
            PerformAction();

            // ���� ĵ���� Ȱ��ȭ
            Invoke("EnableNextCanvas", 2.0f);

            // ���� ĵ���� ��Ȱ��ȭ
            Invoke("DisableCanvas", 1.0f);
            correct.Play();

            actionPerformed = true;
        }
    }

    void PerformAction()
    {
        Debug.Log("����Ʈ Ŭ���� ���� ����Ͽ����ϴ�..");
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