using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartFadeOut()
    {
        // FadeOut 효과 코드 실행
        StartCoroutine(FadeOutImage());
    }

    private IEnumerator FadeOutImage()
    {
        Color color = image.color;

        // 투명도를 서서히 줄임
        while (color.a > 0)
        {
            color.a -= Time.deltaTime;
            image.color = color;
            yield return null;
        }

        // 투명도가 0이 되면 이미지를 비활성화
        gameObject.SetActive(false);
    }
}
