using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastObjectOnOff : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject targetObject4;
    public GameObject targetUI;

    private bool hasActivated = false; // UI�� Ȱ��ȭ�Ǿ����� ���θ� �����ϴ� �÷��� ����

    private void Update()
    {
        CheckAndActivate();
    }

    public void CheckAndActivate()
    {
        // hasActivated�� false�� ��쿡�� ������ Ȯ���ϰ� UI�� Ȱ��ȭ�մϴ�
        if (!hasActivated && !targetObject.activeSelf && !targetObject2.activeSelf && !targetObject3.activeSelf && !targetObject4.activeSelf)
        {
            targetUI.SetActive(true);
            hasActivated = true; // UI�� Ȱ��ȭ�� �� �÷��׸� true�� �����մϴ�
        }
    }
}
