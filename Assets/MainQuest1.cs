using Oculus.Interaction;
using UnityEngine;

public class MainQuest1 : MonoBehaviour
{

    public InteractorActiveState leftInteractorState; // �޼� ���ͷ���
    public InteractorActiveState rightInteractorState; // ������ ���ͷ���
    public OVRInput.Controller controller;
    public OVRScreenFade screenFade;

    void Start()
    {
        //interactorState = GetComponent<InteractorActiveState>(); // InteractorActiveState ������Ʈ ��������
        //if (interactorState == null)
        //{
        //    Debug.LogError("InteractorActiveState�� ã�� �� �����ϴ�.");
        //    return;
        //}
    }

    void Update()
    {

        // �� �� ��� Ȱ��ȭ�Ǿ� �ִ��� Ȯ��
        bool isBothHandsActive = leftInteractorState.Active && rightInteractorState.Active;

        if (isBothHandsActive)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) ||
                OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                // ���̵� �ƿ� ����
                screenFade.FadeOut();
            }
        }
    }
}
