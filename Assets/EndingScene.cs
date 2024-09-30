//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections; // IEnumerator�� ����ϱ� ���� �ʿ��մϴ�.

//public class EndingScene : MonoBehaviour
//{
//    public OVRInput.Controller controller;
//    public float fadeDuration = 2.0f; // ���̵� �ƿ� ���� �ð�
//    public GameObject targetObject; // �浹�� ������ Ÿ�� ������Ʈ

//    private bool isColliding = false; // �浹 ���θ� �����ϴ� ����

//    private void Update()
//    {
//        // ������Ʈ�� �浹 ���̸� Ʈ���� �Է��� �����ϰ� ����� �޽����� ����մϴ�.
//        if (isColliding && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, controller) > 0.5f)
//        {
//            if (OVRScreenFade.instance != null)
//            {
//                OVRScreenFade.instance.FadeOut();
//                StartCoroutine(WaitAndLoadScene(7, fadeDuration));
//            }
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        // Ư�� ������Ʈ�� �浹�� ���
//        if (other.gameObject == targetObject)
//        {
//            Debug.Log("isColliding..");
//            isColliding = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        // Ư�� ������Ʈ���� �浹�� ���� ���
//        if (other.gameObject == targetObject)
//        {
//            isColliding = false;
//        }
//    }

//    private IEnumerator WaitAndLoadScene(int sceneIndex, float waitTime)
//    {
//        Debug.Log("Trigger pressed, starting fade out...");
//        yield return new WaitForSeconds(waitTime);
//        Debug.Log("Loading scene...");
//        SceneManager.LoadScene(sceneIndex);
//    }
//}

//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections; // IEnumerator�� ����ϱ� ���� �ʿ��մϴ�.

//public class EndingScene : MonoBehaviour
//{
//    public OVRInput.Controller controller;
//    public float fadeDuration = 2.0f; // ���̵� �ƿ� ���� �ð�

//    private bool isColliding = false; // �浹 ���θ� �����ϴ� ����

//    private void Update()
//    {
//        // ������Ʈ�� �浹 ���̸� Ʈ���� �Է��� �����ϰ� ����� �޽����� ����մϴ�.
//        if (isColliding && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, controller) > 0.5f)
//        {
//            if (OVRScreenFade.instance != null)
//            {
//                OVRScreenFade.instance.FadeOut();
//                StartCoroutine(WaitAndLoadScene(7, fadeDuration));
//            }
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        // Ư�� ������Ʈ�� �浹�� ���
//        if (other.CompareTag("End"))
//        {
//            Debug.Log("isColliding..");
//            isColliding = true;
//        }
//    }

//    private IEnumerator WaitAndLoadScene(int sceneIndex, float waitTime)
//    {
//        Debug.Log("Trigger pressed, starting fade out...");
//        yield return new WaitForSeconds(waitTime);
//        Debug.Log("Loading scene...");
//        SceneManager.LoadScene(sceneIndex);
//    }
//}
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndingScene : MonoBehaviour
{
    public AudioSource SE;
    public OVRInput.Controller controller;
    public float fadeDuration = 4.0f; // ���̵� �ƿ� ���� �ð�

    private bool isColliding = false; // �浹 ���¸� �����ϱ� ���� ����

    private void Update()
    {
        // �浹 ���ο� Ʈ���� �Է��� Ȯ���մϴ�.
        if (isColliding && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, controller) > 0.5f)
        {
            if (OVRScreenFade.instance != null)
            {
                SE.Play();
                OVRScreenFade.instance.FadeOut();
                StartCoroutine(WaitAndLoadScene(8, fadeDuration));
            }
            else
            {
                Debug.LogWarning("OVRScreenFade.instance�� �������� �ʾҽ��ϴ�.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ư�� ������Ʈ�� �浹 ����
        if (other.CompareTag("End"))
        {
            Debug.Log("�浹 ����..");
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �浹 ���� �� �浹 ���� �缳��
        if (other.CompareTag("End"))
        {
            isColliding = false;
        }
    }

    private IEnumerator WaitAndLoadScene(int sceneIndex, float waitTime)
    {
        Debug.Log("Ʈ���Ű� ���Ƚ��ϴ�, ���̵� �ƿ� ����...");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("�� �ε�...");
        SceneManager.LoadScene("Ending");
    }
}
