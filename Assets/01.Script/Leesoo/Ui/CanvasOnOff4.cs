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
    private float collisionStartTime = 0f; // �浹 ���� �ð�
    private float actionStartTime = 0f; // ����Ʈ ���� �ð�
    public float CameraDistance = 3.0F;
    public Camera Camera2Follow;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public GameObject canvas;
    public GameObject canvas2;
    public float gameOverTime = 30f; // ���ӿ����� �Ѿ�� �ð�
    public float actionTimeLimit = 60f; // ����Ʈ ���� �ð� ����
    public float collisionTimeLimit = 30f; // �浹 ���� �ð� ����
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
        actionStartTime = Time.time; // �ൿ ���� �ð� ����
    }

    void Update()
    {
        
        float elapsedTime = Time.time - actionStartTime;
        float remainingActionTime = actionTimeLimit - elapsedTime;

        // 1�� ���� �ð� ǥ��
        actionTimerText.text = "GameOver: " + remainingActionTime.ToString("F1") + "s";

        // �浹 �ð�
        if (collided)
        {
            float collisionElapsedTime = Time.time - collisionStartTime;
            float remainingCollisionTime = collisionTimeLimit - collisionElapsedTime;

            // �浹 ���� �ð� ǥ��
            collisionTimerText.text = "Collision time: " + remainingCollisionTime.ToString("F1") + "s";

            // �浹 ���ӿ���
            if (collisionElapsedTime >= collisionTimeLimit)
            {
                Debug.Log("Collision time limit reached. Loading GameOver scene.");
                SceneManager.LoadScene("GameOver");
                return;
            }
        }

        
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, CameraDistance));

        // Raycast�� ���� �浹 ����
        RaycastHit hit;
        if (Physics.Raycast(target.position, target.forward, out hit))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            // �浹�� ������Ʈ�� ������ ������Ʈ�� �ݶ��̴����� Ȯ��
            if (hit.collider.gameObject == SeeTarget1 || hit.collider.gameObject == SeeTarget2
                || hit.collider.gameObject == SeeTarget3)
            {
                // �浹�� �߻��� ��� UI ��ġ�� �浹 �������� �ణ ������ ��ġ�� ����
                targetPosition = hit.point + hit.normal * 0.3f;

                if (!collided) //�浹 ����
                {
                    collided = true;
                    collisionStartTime = Time.time; // �浹 ���� �ð�
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

        // UI ��ġ
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 35 * Time.deltaTime);

        // �浹�� �����Ǿ��� ���� Ȱ��ȭ
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
            collisionStartTime = 0f; // �浹�� �������� ������ Ÿ�̸� ����
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
                    // ���̵� �ƿ� ����
                    screenFade.FadeOut();
                    bomb.Play();
                    Invoke("SceneChange", 5f);
                }
            }
        }

        // 1�� ���� �ð��� �ʰ��ϸ� ���ӿ���
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
