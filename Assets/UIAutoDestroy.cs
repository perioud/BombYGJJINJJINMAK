using UnityEngine;
using System.Collections;

public class UIAutoDestroy: MonoBehaviour
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

            // 5초 후에 UI Canvas를 비활성화하고 파괴합니다.
            StartCoroutine(DestroyAfterDelay(13.0f));
        }
    }

    // UI Canvas를 비활성화하고 파괴하는 코루틴
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // UI Canvas를 비활성화합니다.
        uiCanvas.SetActive(false);

        // UI Canvas를 파괴합니다.
        Destroy(uiCanvas);
    }
}
