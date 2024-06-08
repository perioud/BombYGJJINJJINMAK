using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject targetObject2;

    private bool hasActivated = false; // UI�� Ȱ��ȭ�Ǿ����� ���θ� �����ϴ� �÷��� ����

    private void Update()
    {
        CheckAndActivate();
    }

    public void CheckAndActivate()
    {
        // hasActivated�� false�� ��쿡�� ������ Ȯ���ϰ� UI�� Ȱ��ȭ�մϴ�
        if (!hasActivated && targetObject.activeSelf)
        {
            targetObject2.SetActive(true);
            hasActivated = true; // UI�� Ȱ��ȭ�� �� �÷��׸� true�� �����մϴ�
        }
    }
}
