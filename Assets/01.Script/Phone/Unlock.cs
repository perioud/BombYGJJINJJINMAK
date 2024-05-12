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

    // 슬라이더의 값을 100으로 채울 때 호출되는 이벤트 핸들러
    public void OnPointerUp(PointerEventData eventData)
    {
        if (slider != null && slider.value >= 100)
        {
            // 다음 캔버스를 활성화합니다.
            if (nextCanvas != null)
            {
                nextCanvas.SetActive(true);
            }
            else
            {
                Debug.LogWarning("다음 캔버스가 설정되지 않았습니다!");
            }
        }
    }


    void Update()
    {
        // Trigger 버튼을 누르면 드래그 시작
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, controller))
        {
            isDragging = true;
            lastSliderValue = slider.value;
        }

        // Trigger 버튼을 떼면 드래그 종료
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger, controller))
        {
            isDragging = false;
        }

        // 드래그 중이라면 슬라이더 값을 조정
        if (isDragging)
        {
            float input = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, controller);
            slider.value += input * dragSpeed * Time.deltaTime;
        }
    }
}
