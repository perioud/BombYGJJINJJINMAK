using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabArrow : MonoBehaviour
{
    public GameObject Tr;
    public GameObject Arrow;

    private bool isTriggered = false; // ���¸� �����ϴ� ����

    void Update()
    {
        // �� ���� ������� �ʾҰ�, Rigidbody�� kinematic���� Ȯ��
        if (!isTriggered && Tr.transform.GetComponent<Rigidbody>().isKinematic == true)
        {
            // Arrow Ȱ��ȭ
            Arrow.SetActive(true);

            // Arrow�� 15�� �Ŀ� �ı�
            Destroy(Arrow, 15);

            // �̹� ����Ǿ����� ǥ��
            isTriggered = true;
        }
    }
}
