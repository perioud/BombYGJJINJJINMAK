using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;

public class CanvasOnOff4 : MonoBehaviour
{
    #region MyRegion
    public AudioSource nuc;
    public GameObject SeeTarget1;
    public GameObject SeeTarget2;
    public GameObject SeeTarget3;
    public GameObject button1;
    public GameObject button2;
    public InteractorActiveState leftInteractorState;
    public InteractorActiveState rightInteractorState;
    public OVRInput.Controller controller;
    public OVRScreenFade screenFade;
    private Transform target = null;
    private bool collided = false;
    private float collisionStartTime = 0f; // 충돌 시작 시간
    private float actionStartTime = 0f; // 퀘스트 시작 시간
    public float CameraDistance = 3.0F;
    public Camera Camera2Follow;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public GameObject canvas;
    public GameObject canvas2;
    public float gameOverTime = 30f; // 게임오버로 넘어가는 시간
    public float actionTimeLimit = 60f; // 퀘스트 제한 시간 설정
    public float collisionTimeLimit = 30f; // 충돌 제한 시간 설정
    public TMP_Text actionTimerText;
    public TMP_Text collisionTimerText;
    public GameObject collisionTimer;
    public AudioSource bomb;
    #endregion

    void Start()
    {
        SeeTarget1.SetActive(true);
        SeeTarget2.SetActive(true);
        SeeTarget3.SetActive(true);

        nuc.Play();
        target = Camera2Follow.transform;
        actionStartTime = Time.time; // 행동 시작 시간 설정
    }

    void Update()
    {
        
        float elapsedTime = Time.time - actionStartTime;
        float remainingActionTime = actionTimeLimit - elapsedTime;

        // 1분 제한 시간 표시
        actionTimerText.text = "GameOver: " + remainingActionTime.ToString("F1") + "s";

        // 충돌 시간
        if (collided)
        {
            float collisionElapsedTime = Time.time - collisionStartTime;
            float remainingCollisionTime = collisionTimeLimit - collisionElapsedTime;

            // 충돌 제한 시간 표시
            collisionTimerText.text = "Collision time: " + remainingCollisionTime.ToString("F1") + "s";

            // 충돌 게임오버
            if (collisionElapsedTime >= collisionTimeLimit)
            {
                Debug.Log("Collision time limit reached. Loading GameOver scene.");
                SceneManager.LoadScene("GameOver");
                return;
            }
        }

        
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, CameraDistance));

        // Raycast를 통해 충돌 감지
        RaycastHit hit;
        if (Physics.Raycast(target.position, target.forward, out hit))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            // 충돌한 오브젝트가 지정한 오브젝트의 콜라이더인지 확인
            if (hit.collider.gameObject == SeeTarget1 || hit.collider.gameObject == SeeTarget2
                || hit.collider.gameObject == SeeTarget3)
            {
                // 충돌이 발생한 경우 UI 위치를 충돌 지점에서 약간 떨어진 위치로 조정
                targetPosition = hit.point + hit.normal * 0.3f;

                if (!collided) //충돌 감지
                {
                    collided = true;
                    collisionStartTime = Time.time; // 충돌 시작 시간
                }

                Debug.Log("Collision detected with target.");
            }
            else
            {
                collided = false; 
                Debug.Log("No collision with target.");
            }
        }
        else
        {
            collided = false; 
            Debug.Log("No collision detected.");
        }

        // UI 위치
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 35 * Time.deltaTime);

        // 충돌이 감지되었을 때만 활성화
        if (collided)
        {
            Debug.Log("Activating canvas and deactivating canvas2.");
            canvas.SetActive(true);
            canvas2.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            collisionTimer.SetActive(true);

        }
        else
        {
            collisionStartTime = 0f; // 충돌이 감지되지 않으면 타이머 리셋
            Debug.Log("Deactivating canvas and activating canvas2.");
            canvas.SetActive(false);
            canvas2.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
            collisionTimer.SetActive(false);

            bool isBothHandsActive = leftInteractorState.Active && rightInteractorState.Active;

            if (isBothHandsActive)
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) ||
                    OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    // 페이드 아웃 시작
                    screenFade.FadeOut();
                    bomb.Play();
                    Invoke("SceneChange", 5f);
                }
            }
        }

        // 1분 제한 시간이 초과하면 게임오버
        if (remainingActionTime <= 0)
        {
            Debug.Log("Action time limit reached. Loading GameOver scene.");
            SceneManager.LoadScene("GameOver");
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("Main 1");
    }
}
