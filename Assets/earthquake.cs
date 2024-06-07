using System.Collections;
using UnityEngine;

public class earthquake : MonoBehaviour
{
    public bool play;

    public float shakeSpeed = 2.0f;
    public float shakeAmount = 1.0f;
    public float fallSpeed = 1.0f; // 바닥으로 떨어지는 속도

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

            // 오브젝트를 흔들기 위한 코드
            float x = Mathf.Cos(Time.time * 360 * Mathf.Deg2Rad * shakeSpeed) * shakeAmount;

            // 흔들기 속도를 적용하여 오브젝트를 움직이도록 설정
            rb.velocity = new Vector3(x, 0, 0);

            // 오브젝트가 떨어지도록 하는 코드
            if (transform.position.y > 0)
            {
                // 오브젝트를 바닥으로 이동시킴
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            }
        }
    }
}
