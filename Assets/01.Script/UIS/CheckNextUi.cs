using UnityEngine;

public class CheckNextUi : MonoBehaviour
{
    public GameObject[] objectsToCheck; // 체크할 오브젝트 정하기
    public GameObject targetObject; // 모든 오브젝트가 활성화되었을 때 활성화할 오브젝트

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
        allActive = true; // 모든 오브젝트가 활성화된 상태를 기억
    }
}
