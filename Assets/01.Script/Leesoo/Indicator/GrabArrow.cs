using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabArrow : MonoBehaviour
{
    public GameObject Tr;
    public GameObject Arrow;

    private bool isTriggered = false; // 상태를 추적하는 변수

    void Update()
    {
        // 한 번도 실행되지 않았고, Rigidbody가 kinematic인지 확인
        if (!isTriggered && Tr.transform.GetComponent<Rigidbody>().isKinematic == true)
        {
            // Arrow 활성화
            Arrow.SetActive(true);

            // Arrow를 15초 후에 파괴
            Destroy(Arrow, 15);

            // 이미 실행되었음을 표시
            isTriggered = true;
        }
    }
}
