using UnityEngine;
using System.Collections;

public class ObjectFallForward : MonoBehaviour
{
    public float forceAmount = 10f; // ������Ʈ�� ������ �Ѿ����� ���� ũ��
    public GameObject bomb; // Bomb ������Ʈ�� �Ҵ�
    public float shakeDuration = 2f; // ��鸮�� �ð� (��)
    public float shakeMagnitude = 0.1f; // ��鸮�� ũ��

    private Rigidbody rb;
    private bool hasFallen = false; // ������Ʈ�� �̹� �Ѿ������� Ȯ��

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (bomb.activeSelf && !hasFallen) // Bomb ������Ʈ�� Ȱ��ȭ�Ǿ��� ���� ������Ʈ�� �Ѿ����� �ʾ��� ��
        {
            StartCoroutine(ShakeAndFall());
            hasFallen = true; // ������Ʈ�� �Ѿ������� ǥ��
        }
    }

    IEnumerator ShakeAndFall()
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            float z = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = originalPosition + new Vector3(x, y, z);

            // ��鸮�� ���� ������ ���� ���Ͽ� �Ѿ����� ��
            rb.AddForce(transform.forward * (forceAmount * Time.deltaTime), ForceMode.VelocityChange);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // ��鸲�� ���� �� ���� ��ġ�� ����
        transform.position = originalPosition;
    }
}
