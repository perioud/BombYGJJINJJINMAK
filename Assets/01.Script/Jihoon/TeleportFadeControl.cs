using System.Collections;
using UnityEngine;

public class TeleportFadeControlOculus : MonoBehaviour
{
    public ScreenFade screenFade;  // ScreenFade ��ũ��Ʈ ����
    public OVRInput.Controller controller;

    private bool isTeleporting = false; // �ڷ���Ʈ ������ ����

    private void Update()
    {
        // ���̽�ƽ ���� ������ �� �ڷ���Ʈ ����
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp, controller))
        {
            Debug.Log("�ڷ���Ʈ ���� ���� ����");
            isTeleporting = true; // �ڷ���Ʈ ���� ���� ����
        }

        // ���̽�ƽ���� ���� �� �� �ڷ���Ʈ �Ϸ�
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp, controller) && isTeleporting)
        {
            StartCoroutine(OnTeleportEnd());
        }

        // ���̽�ƽ �������� ������ �� ȸ��
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, controller))
        {
            isTeleporting = true;
            StartCoroutine(OnTeleportEnd());

        }
        // ���̽�ƽ ���������� ������ �� ȸ��
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, controller))
        {
            isTeleporting = true;
            StartCoroutine(OnTeleportEnd());
        }
    }


    // �ڷ���Ʈ �Ϸ� �� ���̵� �ƿ�
    private IEnumerator OnTeleportEnd()
    {
        Debug.Log("�ڷ���Ʈ �Ϸ�");
        screenFade?.FadeOut();

        // ���̵� �ƿ��� �Ϸ�� ������ ���
        yield return new WaitUntil(() => !screenFade.IsFading);

        isTeleporting = false;
    }
}
