//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections; // IEnumerator를 사용하기 위해 필요합니다.

//public class EndingScene : MonoBehaviour
//{
//    public OVRInput.Controller controller;
//    public float fadeDuration = 2.0f; // 페이드 아웃 지속 시간
//    public GameObject targetObject; // 충돌을 감지할 타겟 오브젝트

//    private bool isColliding = false; // 충돌 여부를 추적하는 변수

//    private void Update()
//    {
//        // 오브젝트와 충돌 중이며 트리거 입력을 감지하고 디버그 메시지를 출력합니다.
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
//        // 특정 오브젝트와 충돌한 경우
//        if (other.gameObject == targetObject)
//        {
//            Debug.Log("isColliding..");
//            isColliding = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        // 특정 오브젝트와의 충돌이 끝난 경우
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
//using System.Collections; // IEnumerator를 사용하기 위해 필요합니다.

//public class EndingScene : MonoBehaviour
//{
//    public OVRInput.Controller controller;
//    public float fadeDuration = 2.0f; // 페이드 아웃 지속 시간

//    private bool isColliding = false; // 충돌 여부를 추적하는 변수

//    private void Update()
//    {
//        // 오브젝트와 충돌 중이며 트리거 입력을 감지하고 디버그 메시지를 출력합니다.
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
//        // 특정 오브젝트와 충돌한 경우
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
    public float fadeDuration = 4.0f; // 페이드 아웃 지속 시간

    private bool isColliding = false; // 충돌 상태를 추적하기 위한 변수

    private void Update()
    {
        // 충돌 여부와 트리거 입력을 확인합니다.
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
                Debug.LogWarning("OVRScreenFade.instance가 설정되지 않았습니다.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 특정 오브젝트와 충돌 감지
        if (other.CompareTag("End"))
        {
            Debug.Log("충돌 감지..");
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 충돌 종료 시 충돌 상태 재설정
        if (other.CompareTag("End"))
        {
            isColliding = false;
        }
    }

    private IEnumerator WaitAndLoadScene(int sceneIndex, float waitTime)
    {
        Debug.Log("트리거가 눌렸습니다, 페이드 아웃 시작...");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("씬 로딩...");
        SceneManager.LoadScene("Ending");
    }
}
