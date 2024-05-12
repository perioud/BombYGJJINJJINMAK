using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    public Button button; // ��ư ������Ʈ
    public GameObject targetObject; // ��Ȱ��ȭ�� ������Ʈ

    void Start()
    {
        // ��ư Ŭ�� �� �̺�Ʈ�� �Լ� ����
        button.onClick.AddListener(OnClickButton);
    }

    public void OnClickButton()
    {
        // Ÿ�� ������Ʈ�� ��Ȱ��ȭ
        targetObject.SetActive(false);
    }
}
