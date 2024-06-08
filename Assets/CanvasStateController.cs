using UnityEngine;
using UnityEngine.UI;

public class CanvasStateController : MonoBehaviour
{
    public Canvas targetCanvas; // ������ Canvas
    public Outline targetOutline; // Ȱ��ȭ�� Outline ������Ʈ
    private bool wasCanvasActive; // Canvas�� ���� ���¸� �����ϱ� ���� ����

    void Start()
    {
        // �ʱ� ���� ����
        wasCanvasActive = targetCanvas.gameObject.activeSelf;
    }

    void Update()
    {
        // Canvas�� ���� Ȱ��ȭ ���¸� Ȯ��
        bool isCanvasActive = targetCanvas.gameObject.activeSelf;

        // Canvas�� ��Ȱ��ȭ�Ǿ��� �������� Ȱ��ȭ ���¿��� ��
        if (isCanvasActive)
        {
            ActivateOutline();
        }

        // Canvas�� ���� ���¸� ����
        wasCanvasActive = isCanvasActive;
    }

    private void ActivateOutline()
    {
        if (targetOutline != null)
        {
            targetOutline.enabled = true; // Outline ������Ʈ�� Ȱ��ȭ
        }
    }
}
