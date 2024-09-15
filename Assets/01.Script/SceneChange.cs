using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void LoadScene()
    {
        // 3�� �Ŀ� LoadSceneDelayed �޼��带 ȣ��
        Invoke("LoadSceneDelayed", 5.0f);
    }

    private void LoadSceneDelayed()
    {
        // SceneManager�� ����Ͽ� scene�� �ε�
        SceneManager.LoadScene(6); // �ε��� scene�� ���� �ε����� ���� (0�� ù ��° scene)
    }
}
