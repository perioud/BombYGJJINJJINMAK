using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public OVRInput.Controller controller;
    public void LoadScene()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            // 3초 후에 LoadSceneDelayed 메서드를 호출
            Invoke("LoadSceneDelayed", 3.0f);
        }
    }

    private void LoadSceneDelayed()
    {
        // SceneManager를 사용하여 scene을 로드
        SceneManager.LoadScene(0); // 로드할 scene의 빌드 인덱스를 지정 (0은 첫 번째 scene)
    }
}
