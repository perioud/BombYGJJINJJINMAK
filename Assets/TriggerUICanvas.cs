using UnityEngine;

public class TriggerUICanvas : MonoBehaviour
{
    public GameObject uiCanvas; // UI Canvas를 할당할 변수

    // 이 메서드는 다른 콜라이더가 트리거 콜라이더와 충돌했을 때 호출됩니다.
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그가 "Player"인지 확인합니다.
        if (other.CompareTag("Player"))
        {
            // UI Canvas를 활성화합니다.
            uiCanvas.SetActive(true);
        }
    }
}
