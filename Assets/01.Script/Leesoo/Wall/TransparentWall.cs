using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    void Start()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = true; // Ʈ���ŷ� �����Ͽ� �浹 ����
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UIElement"))
        {
            Debug.Log("UI element entered the wall: " + other.gameObject.name);
            other.gameObject.SetActive(false); // UI ��� ��Ȱ��ȭ
        }
    }
}
