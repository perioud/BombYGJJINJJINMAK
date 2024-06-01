using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SeeNuc : MonoBehaviour
{
    public Camera Camera2Follow;
    public GameObject canvas; // 캔버스 객체

    public GameObject targetObject; // 지정한 오브젝트
    public float CameraDistance = 3.0F; // 거리
    public float smoothTime = 0.3F;     // 부드럽게 이동시킬 시간
    private Vector3 velocity = Vector3.zero;
    private Transform target = null;
    private bool collided = false; // 충돌 여부를 저장할 변수

    public Volume globalVolume; // Post Processing Volume

    private Bloom bloom; // 블룸 효과

    void Awake()
    {
        target = Camera2Follow.transform;
        //globalVolume.profile.TryGet(out bloom); // 블룸 효과를 가져옴
    }

    void Update()
    {
        // 카메라가 바라보는 방향으로 UI의 목표 위치 설정
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, CameraDistance));

        // Raycast를 통해 충돌 감지
        RaycastHit hit;
        if (Physics.Raycast(target.position, target.forward, out hit))
        {
            // 충돌한 오브젝트가 지정한 오브젝트의 콜라이더인지 확인
            if (hit.collider.gameObject == targetObject)
            {
                // 충돌이 발생한 경우 UI 위치를 충돌 지점에서 약간 떨어진 위치로 조정
                targetPosition = hit.point + hit.normal * 0.3f;
                collided = true; // 충돌 감지됨

                // 충돌 시 블룸 값을 증가시킴
                if (bloom != null)
                {
                    bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 20f, Time.deltaTime);
                }
            }
            else
            {
                collided = false; // 충돌 감지되지 않음

                if (bloom != null)
                {
                    bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 0f, Time.deltaTime);
                }
            }
        }
        else
        {
            collided = false; // 충돌 감지되지 않음

            // 충돌하지 않을 때 블룸 값을 감소시킴
            if (bloom != null)
            {
                bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 0f, Time.deltaTime);
            }
        }

        // 부드러운 이동을 위해 SmoothDamp 사용하여 UI 이동
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // 카메라를 바라보도록 설정
        transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);

        // UI가 카메라의 회전을 따르도록 설정
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 35 * Time.deltaTime);

        // 충돌이 감지되었을 때만 캔버스를 활성화
        if (collided)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}
