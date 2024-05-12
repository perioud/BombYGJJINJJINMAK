using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnClick : MonoBehaviour
{
    public Color normalColor = Color.white; // �⺻ ����
    public Color clickedColor = Color.red; // Ŭ�� �� ����

    private Image buttonImage; // ��ư�� �̹��� ������Ʈ

    void Start()
    {
        // ��ư�� �̹��� ������Ʈ ��������
        buttonImage = GetComponent<Image>();
    }

    public void ChangeColor()
    {
        // ��ư ���� ����
        buttonImage.color = clickedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
