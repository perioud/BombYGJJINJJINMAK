using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRSliderControl : MonoBehaviour
{
    public Slider uiSlider; // UI �����̴�

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
        // VR ��Ʈ�ѷ��� �����̴��� ������ �� �ʿ��� ������ ���⿡ �߰��� �� �ֽ��ϴ�.
    }

    public void OnSliderValueChanged(float value)
    {
        Debug.Log("Slider Value: " + value);
        // �����̴� �� ���� �� ȣ��Ǵ� �޼���
    }
}
