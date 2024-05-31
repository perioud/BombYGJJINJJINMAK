using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckmarkManager : MonoBehaviour
{
    public List<Image> checkmarks; // 체크마크 이미지들을 저장할 리스트
    public GameObject nextUI; // 다음 UI를 참조할 변수

    private void Start()
    {
        // 초기 상태에서 모든 체크마크가 비활성화되어 있는지 확인
        foreach (Image checkmark in checkmarks)
        {
            checkmark.gameObject.SetActive(false); // 초기 비활성화
        }
        nextUI.SetActive(false); // 다음 UI 초기 비활성화
    }

    public void UpdateCheckmarkStatus(int index)
    {
        if (index < 0 || index >= checkmarks.Count)
        {
            Debug.LogError("Invalid index for checkmark");
            return;
        }

        // 체크마크를 활성화
        checkmarks[index].gameObject.SetActive(true);

        // 모든 체크마크가 활성화되었는지 확인
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
        nextUI.SetActive(true); // 다음 UI 활성화
        Debug.Log("All checkmarks are active. Showing next UI.");
    }
}
