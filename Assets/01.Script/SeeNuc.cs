using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SeeNuc : MonoBehaviour
{
    public Camera Camera2Follow;
    public GameObject canvas; // ĵ���� ��ü

    public GameObject targetObject; // ������ ������Ʈ
    public float CameraDistance = 3.0F; // �Ÿ�
    public float smoothTime = 0.3F;     // �ε巴�� �̵���ų �ð�
    private Vector3 velocity = Vector3.zero;
    private Transform target = null;
    private bool collided = false; // �浹 ���θ� ������ ����

    public Volume globalVolume; // Post Processing Volume

    private Bloom bloom; // ��� ȿ��

    void Awake()
    {
        target = Camera2Follow.transform;
        //globalVolume.profile.TryGet(out bloom); // ��� ȿ���� ������
    }

    void Update()
    {
        // ī�޶� �ٶ󺸴� �������� UI�� ��ǥ ��ġ ����
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, CameraDistance));

        // Raycast�� ���� �浹 ����
        RaycastHit hit;
        if (Physics.Raycast(target.position, target.forward, out hit))
        {
            // �浹�� ������Ʈ�� ������ ������Ʈ�� �ݶ��̴����� Ȯ��
            if (hit.collider.gameObject == targetObject)
            {
                // �浹�� �߻��� ��� UI ��ġ�� �浹 �������� �ణ ������ ��ġ�� ����
                targetPosition = hit.point + hit.normal * 0.3f;
                collided = true; // �浹 ������

                // �浹 �� ��� ���� ������Ŵ
                if (bloom != null)
                {
                    bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 20f, Time.deltaTime);
                }
            }
            else
            {
                collided = false; // �浹 �������� ����

                if (bloom != null)
                {
                    bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 0f, Time.deltaTime);
                }
            }
        }
        else
        {
            collided = false; // �浹 �������� ����

            // �浹���� ���� �� ��� ���� ���ҽ�Ŵ
            if (bloom != null)
            {
                bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 0f, Time.deltaTime);
            }
        }

        // �ε巯�� �̵��� ���� SmoothDamp ����Ͽ� UI �̵�
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // ī�޶� �ٶ󺸵��� ����
        transform.LookAt(transform.position + Camera2Follow.transform.rotation * Vector3.forward, Camera2Follow.transform.rotation * Vector3.up);

        // UI�� ī�޶��� ȸ���� �������� ����
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 35 * Time.deltaTime);

        // �浹�� �����Ǿ��� ���� ĵ������ Ȱ��ȭ
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
