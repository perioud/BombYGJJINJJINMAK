using UnityEngine;

public class CheckNextUi : MonoBehaviour
{
    public GameObject[] objectsToCheck; // üũ�� ������Ʈ ���ϱ�
    public GameObject targetObject; // ��� ������Ʈ�� Ȱ��ȭ�Ǿ��� �� Ȱ��ȭ�� ������Ʈ

    private bool allActive = false;

    private void Start()
    {
        targetObject.SetActive(false);
    }

    private void Update()
    {
        if (!allActive && AreAllObjectsActive())
        {
            ActivateTargetObject();
        }
    }

    private bool AreAllObjectsActive()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            if (!obj.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }

    private void ActivateTargetObject()
    {
        targetObject.SetActive(true);
        allActive = true; // ��� ������Ʈ�� Ȱ��ȭ�� ���¸� ���
    }
}
