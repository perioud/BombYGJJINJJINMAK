using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera Camera2Follow;
    public float CameraDistance = 3.0F; // 거리
    public float smoothTime = 0.3F;     // 부드럽게 이동시킬 시간
    private Vector3 velocity = Vector3.zero;
    private Transform target = null;

    void Awake()
    {
        target = Camera2Follow.transform;
    }

    void Update()
    {
        // 카메라가 바라보는 방향으로 UI의 목표 위치 설정
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, CameraDistance));

        //// 카메라 시야에 있는 벽의 충돌 감지
        //RaycastHit hit;
        //if (Physics.Linecast(target.position, targetPosition, out hit))
        //{
        //    // 충돌이 발생한 경우 UI 위치를 충돌 지점에서 약간 떨어진 위치로 조정
        //    targetPosition = hit.point + hit.normal * 0.3f;
        //}

        // 부드러운 이동을 위해 SmoothDamp 사용하여 UI 이동
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
       

        // 카메라를 바라보도록 설정
        transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);

        // UI가 카메라의 회전을 따르도록 설정
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 35 * Time.deltaTime);

        
    }
}