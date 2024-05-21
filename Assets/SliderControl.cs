using UnityEngine;

public class SliderControl : MonoBehaviour
{
    public float minValue = 0f; // �����̴��� �ּ� ��
    public float maxValue = 1f; // �����̴��� �ִ� ��
    public Transform handle; // �����̴� �ڵ�

    private Vector3 initialPosition;
    private float sliderRange;

    void Start()
    {
        // �����̴� �ڵ��� �ʱ� ��ġ�� �����մϴ�.
        initialPosition = handle.localPosition;
        sliderRange = maxValue - minValue;
    }

    void Update()
    {
        // �����̴� �ڵ��� ��ġ�� �����մϴ�.
        Vector3 localPos = handle.localPosition;
        localPos.z = Mathf.Clamp(localPos.z, initialPosition.z + minValue, initialPosition.z + maxValue);
        handle.localPosition = localPos;
    }
}
