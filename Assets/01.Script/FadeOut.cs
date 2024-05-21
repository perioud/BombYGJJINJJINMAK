using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image image; // 페이드 아웃할 이미지
    public SceneChange sceneChange; // SceneChange 스크립트 참조
    public GameObject hand;
    public GameObject hand2;
    public GameObject laser;
    public GameObject laser2;



    public void StartFadeOut()
    {
        // FadeOut 효과 코드 실행
        StartCoroutine(FadeOutImage());

        hand.gameObject.SetActive(false);
        hand2.gameObject.SetActive(false);
        laser.gameObject.SetActive(false);
        laser2.gameObject.SetActive(false);


    }

    private IEnumerator FadeOutImage()
    {
        Color color = image.color;

        while (color.a > 0)
        {
            color.a -= 0.03f;
            image.color = color;
            yield return null;
        }

        // 투명도가 0이 되면 이미지를 비활성화
        image.gameObject.SetActive(false);

        // 페이드 아웃이 끝난 후 SceneChange의 LoadScene 호출
        if (sceneChange != null)
        {
            sceneChange.LoadScene();
        }
    }
}
