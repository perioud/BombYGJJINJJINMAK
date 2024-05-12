using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;  // 플레이어

    // 카메라가 통과하지 못할 오브젝트의 레이어
    public LayerMask cameraCollision;

    void Update()
    {

        // 플레이어에서부터 카메라까지의 방향 구하기
        Vector3 rayDir = transform.position - player.position;

        // 플레이어에서 카메라 방향으로 Ray 발사
        if (Physics.Raycast(player.position, rayDir, out RaycastHit hit, float.MaxValue, cameraCollision))
        {
            // 맞은 부위보다 더 안쪽으로 위치 이동
            transform.position = hit.point - rayDir.normalized;
        }
    }
}
