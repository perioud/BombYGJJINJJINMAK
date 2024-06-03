using UnityEngine;

public class RotateForward : MonoBehaviour
{
    public float rotationSpeed = 30f; // ȸ�� �ӵ� ������ ���� ����
    private bool isColliding = false;
    public GameObject target;

    private bool isTargetSet = false; // "target" ������ �����Ǿ����� ���θ� ��Ÿ���� ����

    private void Start()
    {
        // Start �Լ����� "target" ������ ������ ������ ���
        WaitForTarget();
    }

    void Update()
    {
        // "target" ������ �����Ǿ��ٸ� ȸ��
        if (isTargetSet && !isColliding)
        {
            target.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    // "target" ������ ������ ������ ����ϴ� �Լ�
    void WaitForTarget()
    {
        if (target != null)
        {
            // "target" ������ ������ ������ InvokeRepeating �Լ��� ���� ���������� üũ
            InvokeRepeating("CheckTarget", 0f, 0.1f);
        }
    }

    // "target" ������ �����Ǿ����� Ȯ���ϴ� �Լ�
    void CheckTarget()
    {
        if (target != null)
        {
            isTargetSet = true; // "target" ������ �����Ǹ� �÷��׸� true�� �����ϰ� ��� ����
            CancelInvoke("CheckTarget"); // InvokeRepeating ����
        }
    }

    // �浹 ���� �� ȣ��Ǵ� �Լ�
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isColliding = true;
        }
    }
}
