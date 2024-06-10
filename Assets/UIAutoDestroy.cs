using UnityEngine;
using System.Collections;

public class UIAutoDestroy: MonoBehaviour
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

            // 5�� �Ŀ� UI Canvas�� ��Ȱ��ȭ�ϰ� �ı��մϴ�.
            StartCoroutine(DestroyAfterDelay(13.0f));
        }
    }

    // UI Canvas�� ��Ȱ��ȭ�ϰ� �ı��ϴ� �ڷ�ƾ
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // UI Canvas�� ��Ȱ��ȭ�մϴ�.
        uiCanvas.SetActive(false);

        // UI Canvas�� �ı��մϴ�.
        Destroy(uiCanvas);
    }
}
