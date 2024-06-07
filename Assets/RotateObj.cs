using UnityEngine;

public class RotateForward : MonoBehaviour
{
    public float rotationSpeed = 30f; // 회전 속도 조절을 위한 변수
    private bool isColliding = false;
    public GameObject target;

    private bool isTargetSet = false; // "target" 변수가 설정되었는지 여부를 나타내는 변수

    private void Start()
    {
        // Start 함수에서 "target" 변수가 설정될 때까지 대기
        WaitForTarget();
    }

    void Update()
    {
        // "target" 변수가 설정되었다면 회전
        if (isTargetSet && !isColliding)
        {
            target.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    // "target" 변수가 설정될 때까지 대기하는 함수
    void WaitForTarget()
    {
        if (target != null)
        {
            // "target" 변수가 설정될 때까지 InvokeRepeating 함수를 통해 지속적으로 체크
            InvokeRepeating("CheckTarget", 0f, 0.1f);
        }
    }

    // "target" 변수가 설정되었는지 확인하는 함수
    void CheckTarget()
    {
        if (target != null)
        {
            isTargetSet = true; // "target" 변수가 설정되면 플래그를 true로 설정하고 대기 종료
            CancelInvoke("CheckTarget"); // InvokeRepeating 중지
        }
    }

    // 충돌 시작 시 호출되는 함수
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isColliding = true;
        }
    }
}
