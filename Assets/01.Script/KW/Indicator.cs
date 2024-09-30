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
        // 충돌한 오브젝트가 Player 태그를 가졌는지 확인
        if (other.CompareTag("Player"))
        {
            OffIndcator.SetActive(false);
        }
    }
}
