using TMPro;
using UnityEngine;

public class TextMeshProController : MonoBehaviour
{
    public TMP_Text text; // TextMeshPro Text ��Ҹ� ������ ����

    void Start()
    {
        // TextMeshPro Text ��Ұ� null�� �ƴ��� Ȯ���ϰ� �ʱ�ȭ�մϴ�.
        if (text != null)
        {
            // TextMeshPro Text�� ��ġ�� ���� ������� �����մϴ�.
            text.rectTransform.anchorMin = new Vector2(0, 1); // ���� ���
            text.rectTransform.anchorMax = new Vector2(0, 1); // ���� ���
            text.rectTransform.pivot = new Vector2(0, 1); // ���� ���
            text.rectTransform.anchoredPosition = new Vector2(0, 0); // ���� ��ܿ����� ��ġ (�⺻��)

            // �߰����� ���� (ũ��, ��Ʈ, ���� ��)
            //text.fontSize = 24;
            //text.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/ARIAL SDF"); // ���ϴ� ��Ʈ�� �ε��մϴ�.
            //text.color = Color.white;
        }
    }
}
