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
        // Start �޼��尡 ȣ��� �� 3�� �Ŀ� FadeIn �ڵ� ����
    }

    private void Update()
    {
        Invoke("StartFadeIn", 4.0f);
    }
    private void StartFadeIn()
    {
        // FadeIn ȿ�� �ڵ� ����
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
