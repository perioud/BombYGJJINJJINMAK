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
        // FadeOut ȿ�� �ڵ� ����
        StartCoroutine(FadeOutImage());
    }

    private IEnumerator FadeOutImage()
    {
        Color color = image.color;

        // ������ ������ ����
        while (color.a > 0)
        {
            color.a -= Time.deltaTime;
            image.color = color;
            yield return null;
        }

        // ������ 0�� �Ǹ� �̹����� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
