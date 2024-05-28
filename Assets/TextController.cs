using TMPro;
using UnityEngine;

public class TextMeshProController : MonoBehaviour
{
    public TMP_Text text; // TextMeshPro Text 요소를 참조할 변수

    void Start()
    {
        // TextMeshPro Text 요소가 null이 아닌지 확인하고 초기화합니다.
        if (text != null)
        {
            // TextMeshPro Text의 위치를 좌측 상단으로 설정합니다.
            text.rectTransform.anchorMin = new Vector2(0, 1); // 좌측 상단
            text.rectTransform.anchorMax = new Vector2(0, 1); // 좌측 상단
            text.rectTransform.pivot = new Vector2(0, 1); // 좌측 상단
            text.rectTransform.anchoredPosition = new Vector2(0, 0); // 좌측 상단에서의 위치 (기본값)

            // 추가적인 설정 (크기, 폰트, 색상 등)
            //text.fontSize = 24;
            //text.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/ARIAL SDF"); // 원하는 폰트를 로드합니다.
            //text.color = Color.white;
        }
    }
}
