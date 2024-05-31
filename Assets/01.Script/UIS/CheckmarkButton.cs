using UnityEngine;

public class CheckmarkButton : MonoBehaviour
{
    public int checkmarkIndex;

    public void OnCheckmarkButtonClick()
    {
        CheckmarkManager checkmarkManager = FindObjectOfType<CheckmarkManager>();
        if (checkmarkManager != null)
        {
            checkmarkManager.UpdateCheckmarkStatus(checkmarkIndex);
        }
        else
        {
            Debug.LogError("CheckmarkManager not found in the scene.");
        }
    }
}
