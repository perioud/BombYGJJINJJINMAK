using System.Collections;
using UnityEngine;

public class earthquake : MonoBehaviour
{
    public bool play;

    public float shakeSpeed = 2.0f;
    public float shakeAmount = 1.0f;
    public float fallSpeed = 1.0f; // �ٴ����� �������� �ӵ�

    Rigidbody rb;
    Vector3 originPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originPosition = transform.localPosition;
    }

    void Update()
    {
        if (play)
        {
            float elapsedTime = 0.0f;

            // ������Ʈ�� ���� ���� �ڵ�
            float x = Mathf.Cos(Time.time * 360 * Mathf.Deg2Rad * shakeSpeed) * shakeAmount;

            // ���� �ӵ��� �����Ͽ� ������Ʈ�� �����̵��� ����
            rb.velocity = new Vector3(x, 0, 0);

            // ������Ʈ�� ���������� �ϴ� �ڵ�
            if (transform.position.y > 0)
            {
                // ������Ʈ�� �ٴ����� �̵���Ŵ
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            }
        }
    }
}
