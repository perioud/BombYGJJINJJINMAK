using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Unlock : MonoBehaviour
{
    public Slider slider;
    public GameObject nextCanvas;
    public OVRInput.Controller controller;
    public float dragSpeed = 0.1f;

    private bool isDragging = false;
    private float lastSliderValue;

    // �����̴��� ���� 100���� ä�� �� ȣ��Ǵ� �̺�Ʈ �ڵ鷯
    public void OnPointerUp(PointerEventData eventData)
    {
        if (slider != null && slider.value >= 100)
        {
            // ���� ĵ������ Ȱ��ȭ�մϴ�.
            if (nextCanvas != null)
            {
                nextCanvas.SetActive(true);
            }
            else
            {
                Debug.LogWarning("���� ĵ������ �������� �ʾҽ��ϴ�!");
            }
        }
    }


    void Update()
    {
        // Trigger ��ư�� ������ �巡�� ����
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, controller))
        {
            isDragging = true;
            lastSliderValue = slider.value;
        }

        // Trigger ��ư�� ���� �巡�� ����
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger, controller))
        {
            isDragging = false;
        }

        // �巡�� ���̶�� �����̴� ���� ����
        if (isDragging)
        {
            float input = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, controller);
            slider.value += input * dragSpeed * Time.deltaTime;
        }
    }
}
