using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckmarkManager : MonoBehaviour
{
    public List<Image> checkmarks; // üũ��ũ �̹������� ������ ����Ʈ
    public GameObject nextUI; // ���� UI�� ������ ����

    private void Start()
    {
        // �ʱ� ���¿��� ��� üũ��ũ�� ��Ȱ��ȭ�Ǿ� �ִ��� Ȯ��
        foreach (Image checkmark in checkmarks)
        {
            checkmark.gameObject.SetActive(false); // �ʱ� ��Ȱ��ȭ
        }
        nextUI.SetActive(false); // ���� UI �ʱ� ��Ȱ��ȭ
    }

    public void UpdateCheckmarkStatus(int index)
    {
        if (index < 0 || index >= checkmarks.Count)
        {
            Debug.LogError("Invalid index for checkmark");
            return;
        }

        // üũ��ũ�� Ȱ��ȭ
        checkmarks[index].gameObject.SetActive(true);

        // ��� üũ��ũ�� Ȱ��ȭ�Ǿ����� Ȯ��
        if (AreAllCheckmarksActive())
        {
            ShowNextUI();
        }
    }

    private bool AreAllCheckmarksActive()
    {
        foreach (Image checkmark in checkmarks)
        {
            if (!checkmark.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    private void ShowNextUI()
    {
        nextUI.SetActive(true); // ���� UI Ȱ��ȭ
        Debug.Log("All checkmarks are active. Showing next UI.");
    }
}
