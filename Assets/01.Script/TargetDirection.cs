using UnityEngine;

public class TargetDirection: MonoBehaviour
{
    public Transform player; // �÷��̾� ĳ������ ��ġ
    public Transform target; // ��ǥ ������ ��ġ

    void Update()
    {
        Vector3 direction = target.position - player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
