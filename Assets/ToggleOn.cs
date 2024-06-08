using UnityEngine;

public class ToggleOn : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject toggle1;
    public GameObject toggle2;
    public GameObject toggle3;
    public GameObject toggle4;

    private void Update()
    {
        CheckAndActivateToggles();
    }
    public void CheckAndActivateToggles()
    {
        if (targetObject.activeSelf)
        {
            toggle1.SetActive(true);
            toggle2.SetActive(true);
            toggle3.SetActive(true);
            toggle4.SetActive(true);
        }
    }
}
