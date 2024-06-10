using UnityEngine;

public class UITriggerInOut : MonoBehaviour
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

    // �ʿ信 ���� UI Canvas�� ��Ȱ��ȭ�� ���� �ֽ��ϴ�.
    private void OnTriggerExit(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "Player"���� Ȯ���մϴ�.
        if (other.CompareTag("Player"))
        {
            // UI Canvas�� ��Ȱ��ȭ�մϴ�.
            uiCanvas.SetActive(false);
        }
    }
}
