using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    public Button button; // 버튼 컴포넌트
    public GameObject targetObject; // 비활성화할 오브젝트

    void Start()
    {
        // 버튼 클릭 시 이벤트에 함수 연결
        button.onClick.AddListener(OnClickButton);
    }

    public void OnClickButton()
    {
        // 타겟 오브젝트를 비활성화
        targetObject.SetActive(false);
    }
}
