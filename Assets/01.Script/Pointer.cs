using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public Transform raycastOrigin; // ���� ���� ����
    public OVRInput.Controller controller;
    public LineRenderer lineRenderer;
    public Color noHitColor = Color.red; // ���̰� ���� �ʾ��� �� ����
    public Color hitColor = Color.green; // ���̰� ����� �� ����
    private Outline outline;
    public float raycastDistance;
    private RaycastHit hit;
    private Button currentButton; // ���� �浹�� ��ư
    private Toggle currentToggle; // ���� �浹�� ���
    private Slider currentSlider; // ���� �浹�� �����̴�
    private GameObject ItemUi; // ���� �浹�� Item ������Ʈ // UI on /off

    void Start()
    {
        lineRenderer.startColor = noHitColor;
        lineRenderer.endColor = noHitColor;
    }

    void Update()
    {
        // ����ĳ��Ʈ�� Ʈ���� ��ư ���¿� ���� Ȱ��ȭ/��Ȱ��ȭ
        if (OVRInput.Get(OVRInput.Button.Two, controller))
        {
            lineRenderer.enabled = true;
            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);
            int layerMask = LayerMask.GetMask("Grabbables", "UI");

            // ����ĳ��Ʈ �浹 ����
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layerMask))
            {
                Debug.Log("Hit an object: " + hit.collider.gameObject.name);

                lineRenderer.startColor = hitColor;
                lineRenderer.endColor = hitColor;
                Vector3 endPoint = transform.position + transform.forward * hit.distance;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, endPoint);

                // ���� �浹�� ������Ʈ�� Button ������Ʈ�� ������ �ִٸ� Ŭ�� ó��
                Button button = hit.collider.gameObject.GetComponent<Button>();
                if (button != null)
                {
                    currentButton = button; // ���� �浹�� ��ư ������Ʈ
                }

                Toggle toggle = hit.collider.gameObject.GetComponent<Toggle>();
                if (toggle != null)
                {
                    currentToggle = toggle; // ���� �浹�� ��� ������Ʈ
                }

                Slider slider = hit.collider.gameObject.GetComponent<Slider>();
                if (slider != null)
                {
                    currentSlider = slider; // ���� �浹�� �����̴� ������Ʈ
                }

                // "Item" �±׸� ���� ������Ʈ ���� // UI on/off
                if (hit.collider.CompareTag("Item"))
                {
                    GameObject itemObject = hit.collider.gameObject;
                    if (ItemUi != itemObject)
                    {
                        if (ItemUi != null)
                        {
                            ItemUi.transform.GetChild(0).gameObject.SetActive(false);
                        }
                        ItemUi = itemObject;
                        ItemUi.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (ItemUi != null)
                    {
                        ItemUi.transform.GetChild(0).gameObject.SetActive(false);
                        ItemUi = null;
                    }
                }
            }
            else
            {
                // ���̾ �浹���� ���� ���
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + (transform.forward * raycastDistance));
                lineRenderer.startColor = noHitColor;
                lineRenderer.endColor = noHitColor;

                // ���� ��ư �ʱ�ȭ
                currentButton = null;
                currentToggle = null;
                currentSlider = null;

                // ���� Item �ʱ�ȭ // UI on/off
                if (ItemUi != null)
                {
                    ItemUi.transform.GetChild(0).gameObject.SetActive(false);
                    ItemUi = null;
                }
            }

            // Ʈ���� ��ư�� ������ ��
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                // ���� �浹�� ��ư�� �ְ� �� ��ư�� Ȱ��ȭ�� �����̸�
                if (currentButton != null && currentButton.IsActive())
                {
                    // ��ư�� Ŭ��
                    currentButton.onClick.Invoke();
                    Debug.Log("Clicked button: " + currentButton.gameObject.name);
                }

                if (currentToggle != null && currentToggle.IsActive())
                {
                    currentToggle.onValueChanged.Invoke(!currentToggle.isOn);
                    Debug.Log("Clicked toggle: " + currentToggle.gameObject.name);
                }

                // Slider ��� ������ �ʿ信 ���� �߰�
            }
        }
        else
        {
            // ����ĳ��Ʈ�� ��Ȱ��ȭ
            lineRenderer.enabled = false;

            // ���� ItemUi �ʱ�ȭ // UI on/off
            if (ItemUi != null)
            {
                ItemUi.transform.GetChild(0).gameObject.SetActive(false);
                ItemUi = null;
            }
        }
    }
}
