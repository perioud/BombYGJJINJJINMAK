using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationSystem : MonoBehaviour
{
    public GameObject targetUI; // Ư�� UI ���
    public Image popupImage; // �˾��� �̹���
    public AudioSource notificationSound; // �˸� ����
    public float delay = 5f; // �̹��� ǥ�ñ����� ���� �ð� (�� ����)
    public float displayDuration = 10f; // �̹����� ǥ���� �ð� (�� ����)

    private bool isNotificationShown = false; // �̹����� �̹� ǥ�õǾ����� ���θ� ��Ÿ���� �÷���
    private bool isSoundPlayed = false; // ���尡 �̹� ����Ǿ����� ���θ� ��Ÿ���� �÷���

    void Start()
    {
        // �ʱ� ���·� �˾� �̹����� ��Ȱ��ȭ
        popupImage.gameObject.SetActive(false);
    }

    void Update()
    {
        // Ư�� UI�� Ȱ��ȭ�Ǿ��� �̹����� ǥ�õ��� ���� ���
        if (targetUI.activeSelf && !isNotificationShown)
        {
            StartCoroutine(ShowPopupAfterDelay());
        }
    }

    private IEnumerator ShowPopupAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        // �̹��� ǥ��
        if (!isNotificationShown)
        {
            // �̹��� ǥ�� �÷��� ����
            isNotificationShown = true;

            // �˸� ���� ���
            if (notificationSound != null && !isSoundPlayed)
            {
                // ���� ��� �÷��� ����
                isSoundPlayed = true;

                // �˸� ���� ���
                notificationSound.Play();
            }

            // �˾� �̹��� Ȱ��ȭ
            popupImage.gameObject.SetActive(true);

            // ���� �ð� �� �̹����� ��Ȱ��ȭ�ϴ� �ڷ�ƾ ����
            StartCoroutine(HidePopupAfterDuration());
        }
    }

    private IEnumerator HidePopupAfterDuration()
    {
        yield return new WaitForSeconds(displayDuration);

        // �̹����� ��Ȱ��ȭ
        popupImage.gameObject.SetActive(false);
    }
}
