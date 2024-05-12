using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnClick : MonoBehaviour
{
    public Color normalColor = Color.white; // 기본 색상
    public Color clickedColor = Color.red; // 클릭 시 색상

    private Image buttonImage; // 버튼의 이미지 컴포넌트

    void Start()
    {
        // 버튼의 이미지 컴포넌트 가져오기
        buttonImage = GetComponent<Image>();
    }

    public void ChangeColor()
    {
        // 버튼 색상 변경
        buttonImage.color = clickedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
