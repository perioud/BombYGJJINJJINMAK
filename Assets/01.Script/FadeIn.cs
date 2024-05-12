using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        // Start 메서드가 호출된 후 3초 후에 FadeIn 코드 실행
    }

    private void Update()
    {
        Invoke("StartFadeIn", 4.0f);
    }
    private void StartFadeIn()
    {
        // FadeIn 효과 코드 실행
        FadeInImage();
    }

    private void FadeInImage()
    {
        Color color = image.color;

        if (color.a < 255)
        {
            color.a += Time.deltaTime;
        }

        image.color = color;
    }
}
