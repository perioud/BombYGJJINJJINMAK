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

    private bool hasActivated = false; // UI가 활성화되었는지 여부를 추적하는 플래그 변수

    private void Update()
    {
        CheckAndActivate();
    }

    public void CheckAndActivate()
    {
        // hasActivated가 false인 경우에만 조건을 확인하고 UI를 활성화합니다
        if (!hasActivated && !targetObject.activeSelf && !targetObject2.activeSelf && !targetObject3.activeSelf && !targetObject4.activeSelf)
        {
            targetUI.SetActive(true);
            hasActivated = true; // UI를 활성화한 후 플래그를 true로 설정합니다
        }
    }
}
