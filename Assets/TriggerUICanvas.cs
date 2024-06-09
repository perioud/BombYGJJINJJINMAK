using UnityEngine;

public class TriggerUICanvas : MonoBehaviour
{
    public GameObject uiCanvas; // UI Canvas�� �Ҵ��� ����

    // �� �޼���� �ٸ� �ݶ��̴��� Ʈ���� �ݶ��̴��� �浹���� �� ȣ��˴ϴ�.
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "Player"���� Ȯ���մϴ�.
        if (other.CompareTag("Player"))
        {
            // UI Canvas�� Ȱ��ȭ�մϴ�.
            uiCanvas.SetActive(true);
        }
    }
}
