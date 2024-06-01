using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MQScene : MonoBehaviour
{
    public Button button; // 버튼 컴포넌트

    void Start()
    {
        // 버튼 클릭 시 이벤트에 함수 연결
        button.onClick.AddListener(OnClickButton);
    }

    public void OnClickButton()
    {
        Debug.Log("Action time limit reached. Loading GameOver scene.");
        SceneManager.LoadScene("MainQuest");
    }


}
