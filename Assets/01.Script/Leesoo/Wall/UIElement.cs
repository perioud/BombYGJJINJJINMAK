using UnityEngine;

public class UIElement : MonoBehaviour
{
    private Vector3 lastValidPosition;

    void Start()
    {
        lastValidPosition = transform.position; // 초기 위치 저장
    }

    void Update()
    {
        if (IsInsideTransparentWall(transform.position))
        {
            transform.position = lastValidPosition; // 충돌 시 이전 위치로 되돌리기
        }
        else
        {
            lastValidPosition = transform.position; // 유효한 위치 업데이트
        }
    }

    private bool IsInsideTransparentWall(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, 0.1f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("TransparentWall"))
            {
                return true;
            }
        }
        return false;
    }
}
