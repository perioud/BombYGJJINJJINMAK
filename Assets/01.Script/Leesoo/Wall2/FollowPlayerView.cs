using UnityEngine;

public class FollowPlayerView : MonoBehaviour
{
    public Transform playerCamera; // �÷��̾� ī�޶��� Transform
    public Vector3 offset = new Vector3(0.5f, 0.0f, 1.0f); // UI�� ��ġ ������
    public float detectDistance = 1f; // ���� �����ϴ� �Ÿ�
    public float moveSpeed = 5f; // UI�� �̵��ϴ� �ӵ�

    private LayerMask wallLayer;
    private RaycastHit hit;
    private bool isAvoidingWall = false; // �� ȸ�� ���¸� �����ϴ� �÷���

    void Start()
    {
        // �� ���̾� ����
        wallLayer = LayerMask.GetMask("Wall"); // �� ���̾��� �̸��� "Wall"�� ����
    }

    void Update()
    {
        Vector3 targetPosition = playerCamera.position + playerCamera.forward * offset.z + playerCamera.right * offset.x + playerCamera.up * offset.y;
        Vector3 direction = (targetPosition - transform.position).normalized;

        // �� ���� ����ĳ��Ʈ
        if (Physics.Raycast(transform.position, direction, out hit, detectDistance, wallLayer))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                // ���� �����ϸ� UI�� �����κ��� �ָ� �̵���Ű�� ����
                isAvoidingWall = true;
                Vector3 avoidDirection = (transform.position - hit.point).normalized;
                transform.position += avoidDirection * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            // ���� �������� ���� ��� ���������� �÷��̾��� ������ ���� �̵�
            isAvoidingWall = false;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        // UI�� �׻� �÷��̾� ī�޶� ���ϵ��� ȸ��
        transform.LookAt(playerCamera);
        transform.Rotate(0, 180, 0); // UI�� �������� �ʵ��� 180�� ȸ��
    }
}
