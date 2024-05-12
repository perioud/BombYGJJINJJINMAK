using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFadeOut : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Fade Out에 걸리는 시간
    public CanvasGroup canvasGroup; // 캔버스의 CanvasGroup 컴포넌트

    private void Start()
    {
        // 캔버스의 CanvasGroup 컴포넌트 가져오기
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void StartFadeOut()
    {
        // Fade Out 코루틴 실행
        StartCoroutine(FadeOutCanvas());
    }

    private IEnumerator FadeOutCanvas()
    {
        // 페이드 아웃 애니메이션
        float timer = 0.0f;
        while (timer < fadeDuration)
        {
            // 투명도 감소
            canvasGroup.alpha = Mathf.Lerp(1.0f, 0.0f, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // 캔버스 비활성화
        gameObject.SetActive(false);
    }
}
