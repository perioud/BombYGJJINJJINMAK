using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChange : MonoBehaviour
{
    public Button button; // ��ư ������Ʈ
    public GameObject targetObject; // ��Ȱ��ȭ�� ������Ʈ
    public GameObject targetObject2; //Ȱ��ȭ�� ������Ʈ

    void Start()
    {
        // ��ư Ŭ�� �� �̺�Ʈ�� �Լ� ����
        button.onClick.AddListener(OffClickButton);
        button.onClick.AddListener(OnClickButton);
    }

    public void OffClickButton()
    {
        // Ÿ�� ������Ʈ�� ��Ȱ��ȭ
        targetObject.SetActive(false);
    }

    public void OnClickButton()
    {
        targetObject2.SetActive(true);
    }

}