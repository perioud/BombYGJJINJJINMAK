using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRSliderControl : MonoBehaviour
{
    public Slider uiSlider; // UI 슬라이더

    void Start()
    {
        if (uiSlider == null)
        {
            Debug.LogError("UI Slider is not assigned.");
            return;
        }
    }

    void Update()
    {
        // VR 컨트롤러로 슬라이더를 조작할 때 필요한 로직을 여기에 추가할 수 있습니다.
    }

    public void OnSliderValueChanged(float value)
    {
        Debug.Log("Slider Value: " + value);
        // 슬라이더 값 변경 시 호출되는 메서드
    }
}
