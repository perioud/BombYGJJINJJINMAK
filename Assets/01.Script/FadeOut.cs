using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image image; // ���̵� �ƿ��� �̹���
    public SceneChange sceneChange; // SceneChange ��ũ��Ʈ ����
    public GameObject hand;
    public GameObject hand2;
    public GameObject laser;
    public GameObject laser2;



    public void StartFadeOut()
    {
        // FadeOut ȿ�� �ڵ� ����
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

        // ������ 0�� �Ǹ� �̹����� ��Ȱ��ȭ
        image.gameObject.SetActive(false);

        // ���̵� �ƿ��� ���� �� SceneChange�� LoadScene ȣ��
        if (sceneChange != null)
        {
            sceneChange.LoadScene();
        }
    }
}
