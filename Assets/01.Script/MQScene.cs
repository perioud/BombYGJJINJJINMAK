using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MQScene : MonoBehaviour
{
    public Button button; // ��ư ������Ʈ

    void Start()
    {
        // ��ư Ŭ�� �� �̺�Ʈ�� �Լ� ����
        button.onClick.AddListener(OnClickButton);
    }

    public void OnClickButton()
    {
        Debug.Log("Action time limit reached. Loading GameOver scene.");
        SceneManager.LoadScene("MainQuest");
    }


}
