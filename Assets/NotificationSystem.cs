using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationSystem : MonoBehaviour
{
    public GameObject targetUI; // 특정 UI 요소
    public Image popupImage; // 팝업할 이미지
    public AudioSource notificationSound; // 알림 사운드
    public float delay = 5f; // 이미지 표시까지의 지연 시간 (초 단위)
    public float displayDuration = 10f; // 이미지를 표시할 시간 (초 단위)

    private bool isNotificationShown = false; // 이미지가 이미 표시되었는지 여부를 나타내는 플래그
    private bool isSoundPlayed = false; // 사운드가 이미 재생되었는지 여부를 나타내는 플래그

    void Start()
    {
        // 초기 상태로 팝업 이미지를 비활성화
        popupImage.gameObject.SetActive(false);
    }

    void Update()
    {
        // 특정 UI가 활성화되었고 이미지가 표시되지 않은 경우
        if (targetUI.activeSelf && !isNotificationShown)
        {
            StartCoroutine(ShowPopupAfterDelay());
        }
    }

    private IEnumerator ShowPopupAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        // 이미지 표시
        if (!isNotificationShown)
        {
            // 이미지 표시 플래그 설정
            isNotificationShown = true;

            // 알림 사운드 재생
            if (notificationSound != null && !isSoundPlayed)
            {
                // 사운드 재생 플래그 설정
                isSoundPlayed = true;

                // 알림 사운드 재생
                notificationSound.Play();
            }

            // 팝업 이미지 활성화
            popupImage.gameObject.SetActive(true);

            // 일정 시간 후 이미지를 비활성화하는 코루틴 시작
            StartCoroutine(HidePopupAfterDuration());
        }
    }

    private IEnumerator HidePopupAfterDuration()
    {
        yield return new WaitForSeconds(displayDuration);

        // 이미지를 비활성화
        popupImage.gameObject.SetActive(false);
    }
}
