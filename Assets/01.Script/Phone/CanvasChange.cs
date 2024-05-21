using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChange : MonoBehaviour
{
    public Button button; // 버튼 컴포넌트
    public GameObject targetObject; // 비활성화할 오브젝트
    public GameObject targetObject2; //활성화할 오브젝트

    void Start()
    {
        // 버튼 클릭 시 이벤트에 함수 연결
        button.onClick.AddListener(OffClickButton);
        button.onClick.AddListener(OnClickButton);
    }

    public void OffClickButton()
    {
        // 타겟 오브젝트를 비활성화
        targetObject.SetActive(false);
    }

    public void OnClickButton()
    {
        targetObject2.SetActive(true);
    }

}