using UnityEngine;
using UnityEngine.UI;

public class CanvasStateController : MonoBehaviour
{
    public Canvas targetCanvas; // 감시할 Canvas
    public Outline targetOutline; // 활성화할 Outline 컴포넌트
    private bool wasCanvasActive; // Canvas의 이전 상태를 추적하기 위한 변수

    void Start()
    {
        // 초기 상태 설정
        wasCanvasActive = targetCanvas.gameObject.activeSelf;
    }

    void Update()
    {
        // Canvas의 현재 활성화 상태를 확인
        bool isCanvasActive = targetCanvas.gameObject.activeSelf;

        // Canvas가 비활성화되었고 이전에는 활성화 상태였을 때
        if (isCanvasActive)
        {
            ActivateOutline();
        }

        // Canvas의 현재 상태를 저장
        wasCanvasActive = isCanvasActive;
    }

    private void ActivateOutline()
    {
        if (targetOutline != null)
        {
            targetOutline.enabled = true; // Outline 컴포넌트를 활성화
        }
    }
}
