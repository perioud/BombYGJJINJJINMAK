using UnityEngine;

public class UIElement : MonoBehaviour
{
    private Vector3 lastValidPosition;

    void Start()
    {
        lastValidPosition = transform.position; // �ʱ� ��ġ ����
    }

    void Update()
    {
        if (IsInsideTransparentWall(transform.position))
        {
            transform.position = lastValidPosition; // �浹 �� ���� ��ġ�� �ǵ�����
        }
        else
        {
            lastValidPosition = transform.position; // ��ȿ�� ��ġ ������Ʈ
        }
    }

    private bool IsInsideTransparentWall(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, 0.1f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("TransparentWall"))
            {
                return true;
            }
        }
        return false;
    }
}
