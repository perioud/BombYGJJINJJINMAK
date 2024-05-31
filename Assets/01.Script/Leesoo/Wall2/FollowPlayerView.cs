using UnityEngine;

public class FollowPlayerView : MonoBehaviour
{
    public Transform playerCamera; // 플레이어 카메라의 Transform
    public Vector3 offset = new Vector3(0.5f, 0.0f, 1.0f); // UI의 위치 오프셋
    public float detectDistance = 1f; // 벽을 감지하는 거리
    public float moveSpeed = 5f; // UI가 이동하는 속도

    private LayerMask wallLayer;
    private RaycastHit hit;
    private bool isAvoidingWall = false; // 벽 회피 상태를 추적하는 플래그

    void Start()
    {
        // 벽 레이어 설정
        wallLayer = LayerMask.GetMask("Wall"); // 벽 레이어의 이름을 "Wall"로 설정
    }

    void Update()
    {
        Vector3 targetPosition = playerCamera.position + playerCamera.forward * offset.z + playerCamera.right * offset.x + playerCamera.up * offset.y;
        Vector3 direction = (targetPosition - transform.position).normalized;

        // 벽 감지 레이캐스트
        if (Physics.Raycast(transform.position, direction, out hit, detectDistance, wallLayer))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                // 벽을 감지하면 UI를 벽으로부터 멀리 이동시키는 로직
                isAvoidingWall = true;
                Vector3 avoidDirection = (transform.position - hit.point).normalized;
                transform.position += avoidDirection * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            // 벽을 감지하지 않은 경우 정상적으로 플레이어의 시점을 따라 이동
            isAvoidingWall = false;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        // UI가 항상 플레이어 카메라를 향하도록 회전
        transform.LookAt(playerCamera);
        transform.Rotate(0, 180, 0); // UI가 뒤집히지 않도록 180도 회전
    }
}
