using UnityEngine;
using System.Collections;

public class ObjectFallForward : MonoBehaviour
{
    public float forceAmount = 10f; // 오브젝트가 앞으로 넘어지는 힘의 크기
    public GameObject bomb; // Bomb 오브젝트를 할당
    public float shakeDuration = 2f; // 흔들리는 시간 (초)
    public float shakeMagnitude = 0.1f; // 흔들리는 크기

    private Rigidbody rb;
    private bool hasFallen = false; // 오브젝트가 이미 넘어졌는지 확인

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (bomb.activeSelf && !hasFallen) // Bomb 오브젝트가 활성화되었고 아직 오브젝트가 넘어지지 않았을 때
        {
            StartCoroutine(ShakeAndFall());
            hasFallen = true; // 오브젝트가 넘어졌음을 표시
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

            // 흔들리는 동안 앞으로 힘을 가하여 넘어지게 함
            rb.AddForce(transform.forward * (forceAmount * Time.deltaTime), ForceMode.VelocityChange);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // 흔들림이 끝난 후 원래 위치로 복귀
        transform.position = originalPosition;
    }
}
