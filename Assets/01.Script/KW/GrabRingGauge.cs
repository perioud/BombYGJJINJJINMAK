using Oculus.Interaction;
using UnityEngine;
using UnityEngine.UI;

public class GrabRingGauge : MonoBehaviour
{
    public Image ringGauge; // 링 게이지로 사용할 Image 컴포넌트
    public float fillSpeed = 0.7f; // 게이지가 채워지는 속도
    public float drainSpeed = 1.0f; // 게이지가 줄어드는 속도

    private float currentFill = 0f; // 현재 게이지 상태 (0 ~ 1 사이 값)
    //private bool isPlayerInRange = false; // 플레이어가 닿아 있는지 확인하는 변수
    private IActiveState ActiveState { get; set; }
    void Start()
    {
        ActiveState = FindObjectOfType<InteractorActiveState>();

    }
    void Update()
    {
        bool isActive = ActiveState.Active;

        // 플레이어가 범위 내에 있을 때만 게이지 처리
        if (isActive)
        {
            // 그랩 버튼이 눌린 상태일 때 게이지 채우기
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                currentFill += fillSpeed * Time.deltaTime; // 채우기 속도로 게이지 증가
                currentFill = Mathf.Clamp01(currentFill);  // 0 ~ 1 사이로 값 제한
            }
            // 버튼이 떼어진 상태일 때 게이지 줄이기
            else
            {
                currentFill -= drainSpeed * Time.deltaTime; // 줄어들기 속도로 게이지 감소
                currentFill = Mathf.Clamp01(currentFill);  // 0 ~ 1 사이로 값 제한
            }
        }
        else
        {
            // 플레이어가 범위 밖에 있을 때는 게이지가 줄어듦
            currentFill -= drainSpeed * Time.deltaTime; // 줄어들기 속도로 게이지 감소
            currentFill = Mathf.Clamp01(currentFill);  // 0 ~ 1 사이로 값 제한
        }

        // 링 게이지 UI에 현재 값 반영
        ringGauge.fillAmount = currentFill;

        // 게이지가 다 차면 오브젝트 비활성화
        if (currentFill >= 1f)
        {
            gameObject.SetActive(false);
        }
    }

    // 플레이어가 범위 안으로 들어왔을 때
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isPlayerInRange = true; // 플레이어가 범위 내에 있을 때 true
    //    }
    //}

    //// 플레이어가 범위 밖으로 나갔을 때
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isPlayerInRange = false; // 플레이어가 범위 밖으로 나가면 false
    //    }
    //}
}
