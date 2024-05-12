using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
    [SerializeField]
    private GameObject quest;

    void Update()
    {
        ToggleUI();
    }

    // UI 창을 표시하거나 숨기는 메서드
    void ToggleUI()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (quest.transform.GetChild(0).gameObject.activeSelf)
            {
                quest.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                quest.transform.GetChild(0).gameObject.SetActive(true);
            }

        }
    }
}
