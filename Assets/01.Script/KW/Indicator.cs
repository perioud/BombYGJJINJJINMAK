using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject Object1;

    public GameObject OffIndcator;
    public GameObject OnIndcator;

    void Update()
    {
        
        if (Object1.activeSelf)
        {
            Debug.Log("ddd");
            OnIndcator.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Player �±׸� �������� Ȯ��
        if (other.CompareTag("Player"))
        {
            OffIndcator.SetActive(false);
        }
    }
}
