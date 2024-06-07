using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera Camera2Follow;
    public float CameraDistance = 3.0F; // �Ÿ�
    public float smoothTime = 0.3F;     // �ε巴�� �̵���ų �ð�
    private Vector3 velocity = Vector3.zero;
    private Transform target = null;

    void Awake()
    {
        target = Camera2Follow.transform;
    }

    void Update()
    {
        // ī�޶� �ٶ󺸴� �������� UI�� ��ǥ ��ġ ����
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, CameraDistance));

        //// ī�޶� �þ߿� �ִ� ���� �浹 ����
        //RaycastHit hit;
        //if (Physics.Linecast(target.position, targetPosition, out hit))
        //{
        //    // �浹�� �߻��� ��� UI ��ġ�� �浹 �������� �ణ ������ ��ġ�� ����
        //    targetPosition = hit.point + hit.normal * 0.3f;
        //}

        // �ε巯�� �̵��� ���� SmoothDamp ����Ͽ� UI �̵�
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
       

        // ī�޶� �ٶ󺸵��� ����
        transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);

        // UI�� ī�޶��� ȸ���� �������� ����
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 35 * Time.deltaTime);

        
    }
}