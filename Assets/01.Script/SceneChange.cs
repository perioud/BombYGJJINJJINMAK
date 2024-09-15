using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void LoadScene()
    {
        // 3초 후에 LoadSceneDelayed 메서드를 호출
        Invoke("LoadSceneDelayed", 5.0f);
    }

    private void LoadSceneDelayed()
    {
        // SceneManager를 사용하여 scene을 로드
        SceneManager.LoadScene(6); // 로드할 scene의 빌드 인덱스를 지정 (0은 첫 번째 scene)
    }
}
