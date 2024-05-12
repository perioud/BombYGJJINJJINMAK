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
            // 3�� �Ŀ� LoadSceneDelayed �޼��带 ȣ��
            Invoke("LoadSceneDelayed", 3.0f);
        }
    }

    private void LoadSceneDelayed()
    {
        // SceneManager�� ����Ͽ� scene�� �ε�
        SceneManager.LoadScene(0); // �ε��� scene�� ���� �ε����� ���� (0�� ù ��° scene)
    }
}
