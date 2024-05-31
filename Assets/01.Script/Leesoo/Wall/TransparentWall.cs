using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    void Start()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = true; // 트리거로 설정하여 충돌 감지
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UIElement"))
        {
            Debug.Log("UI element entered the wall: " + other.gameObject.name);
            other.gameObject.SetActive(false); // UI 요소 비활성화
        }
    }
}
