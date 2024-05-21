using UnityEngine;

public class SliderControl : MonoBehaviour
{
    public float minValue = 0f; // 슬라이더의 최소 값
    public float maxValue = 1f; // 슬라이더의 최대 값
    public Transform handle; // 슬라이더 핸들

    private Vector3 initialPosition;
    private float sliderRange;

    void Start()
    {
        // 슬라이더 핸들의 초기 위치를 저장합니다.
        initialPosition = handle.localPosition;
        sliderRange = maxValue - minValue;
    }

    void Update()
    {
        // 슬라이더 핸들의 위치를 제한합니다.
        Vector3 localPos = handle.localPosition;
        localPos.z = Mathf.Clamp(localPos.z, initialPosition.z + minValue, initialPosition.z + maxValue);
        handle.localPosition = localPos;
    }
}
