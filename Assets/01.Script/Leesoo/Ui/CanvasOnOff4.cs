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
    public AudioSource bomb;
    public AudioSource correct;
    public AudioSource bomb2;
    public AudioSource ch1Bgm;
    public AudioSource tts;
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
    public GameObject canvas3;
    public float gameOverTime = 10f; // 게임오버로 넘어가는 시간
    public float actionTimeLimit = 60f; // 퀘스트 제한 시간 설정
    public float collisionTimeLimit = 30f; // 실명 제한 시간 설정
    public TMP_Text actionTimerText;
    public TMP_Text collisionTimerText;
    public GameObject collisionTimer;
    private bool q3Active = false;
    private bool readyQ3 = false;

    #endregion

    void Start()
    {
        SeeTarget1.SetActive(true);
        SeeTarget2.SetActive(true);
        SeeTarget3.SetActive(true);
        tts.Play();
        ch1Bgm.Play();
        StartCoroutine(FadeInAudio(ch1Bgm, 15f));
        nuc.Play();
        target = Camera2Follow.transform;
        actionStartTime = Time.time; 
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

            // 실명 제한 시간 표시
            collisionTimerText.text = "blind: " + remainingCollisionTime.ToString("F1") + "s";

            // 실명 게임오버
            if (collisionElapsedTime >= collisionTimeLimit)
            {
                Debug.Log("Collision time limit reached. Loading GameOver scene.");
                screenFade.FadeOut();
                Blind();
                //Invoke("Blind", 1f);
                
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
                //targetPosition = hit.point + hit.normal * 0.3f;

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
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 35 * Time.deltaTime);

        // 충돌이 감지되었을 때만 활성화
        if (collided)
        {
            Debug.Log("Activating canvas and deactivating canvas2.");
            canvas.SetActive(true);
            q3Active = false;
            canvas3.SetActive(false);
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
            if (q3Active == false)
            {
                canvas2.SetActive(true);
                button1.SetActive(true);
                button2.SetActive(true);
            }

            collisionTimer.SetActive(false);

            bool isBothHandsActive = leftInteractorState.Active && rightInteractorState.Active;

            if (isBothHandsActive)
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) ||
                    OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    q3Active = true;
                    correct.Play();
                    //readyQ3 = true;
                    canvas2.SetActive(false);
                    canvas3.SetActive(true);
                    button1.SetActive(false);
                    button2.SetActive(false);
                    Invoke("ReadyQ3", 0.5f);


                    //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) &&
                    //OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                    //{
                    //    // 페이드 아웃 시작
                    //    screenFade.FadeOut();
                    //    bomb.Play();
                    //    Invoke("SceneChange", 5f);
                    //}

                }
            }
        }

        // 1분 제한 시간이 초과하면 게임오버
        if (remainingActionTime <= 0)
        {
            Debug.Log("Action time limit reached. Loading GameOver scene.");
            screenFade.FadeOut();
            GameOver();
            //Invoke("GameOver", 1f);
          
        }

        if(q3Active && readyQ3 == true)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) ||
                        OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                // 페이드 아웃 시작
                screenFade.FadeOut();
                correct.Play();
                bomb2.Play();
                Invoke("SceneChange", 10f);
                StartCoroutine(FadeOutAudio(bomb2, 10f));
                StartCoroutine(FadeOutAudio(ch1Bgm, 10f));
                StartCoroutine(FadeOutAudio(nuc, 10f));

            }
        }


    }
    void ReadyQ3()
    {
        readyQ3 = true;
    }

    // 오디오 페이드인
    IEnumerator FadeInAudio(AudioSource audioSource, float fadeDuration)
    {
        audioSource.volume = 0;
        audioSource.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = t / fadeDuration;
            yield return null;
        }

        audioSource.volume = 1f;
    }

    // 오디오 페이드아웃
    IEnumerator FadeOutAudio(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = startVolume * (1 - t / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }

    void SceneChange()
    {
        SceneManager.LoadScene("Chapter2");
    }

    void Blind()
    {
        SceneManager.LoadScene("blind");
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}
