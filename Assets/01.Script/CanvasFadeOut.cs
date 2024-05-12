using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFadeOut : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Fade Out�� �ɸ��� �ð�
    public CanvasGroup canvasGroup; // ĵ������ CanvasGroup ������Ʈ

    private void Start()
    {
        // ĵ������ CanvasGroup ������Ʈ ��������
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void StartFadeOut()
    {
        // Fade Out �ڷ�ƾ ����
        StartCoroutine(FadeOutCanvas());
    }

    private IEnumerator FadeOutCanvas()
    {
        // ���̵� �ƿ� �ִϸ��̼�
        float timer = 0.0f;
        while (timer < fadeDuration)
        {
            // ���� ����
            canvasGroup.alpha = Mathf.Lerp(1.0f, 0.0f, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // ĵ���� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
