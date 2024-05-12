using UnityEngine;

public class TargetDirection: MonoBehaviour
{
    public Transform player; // 플레이어 캐릭터의 위치
    public Transform target; // 목표 지점의 위치

    void Update()
    {
        Vector3 direction = target.position - player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
