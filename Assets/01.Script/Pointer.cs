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
    public float raycastDistance;
    private RaycastHit hit;
    private Button currentButton; // ���� �浹�� ��ư
    private Toggle currentToggle; // ���� �浹�� ���
    private Slider currentSlider; // ���� �浹�� �����̴�
    private GameObject ItemUi; // ���� �浹�� Item ������Ʈ // UI on /off
    private Outline currentOutline; // ���� �浹�� ������Ʈ�� �ƿ�����

    void Start()
    {
        lineRenderer.startColor = noHitColor;
        lineRenderer.endColor = noHitColor;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.enabled = false; // ó������ LineRenderer�� ��Ȱ��ȭ
                                     
    }

    void Update()
    {
        bool raycastHitSomething = false;

        // �׻� ����ĳ��Ʈ�� ���������� LineRenderer�� ���ܵ�
        int layerMask = LayerMask.GetMask("Grabbables", "UI");

        // ����ĳ��Ʈ �浹 ����
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layerMask))
        {
            Debug.Log("Hit an object: " + hit.collider.gameObject.name);

            raycastHitSomething = true;
            lineRenderer.enabled = true;

            // ���� �������� ���� ����
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
            if (hit.collider.CompareTag("Item") || (hit.collider.CompareTag("Fresh")))
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

            // ���� �浹�� ������Ʈ�� �ƿ����� ó��
            Outline outline = hit.collider.gameObject.GetComponent<Outline>();
            if (outline != null)
            {
                if (currentOutline != outline)
                {
                    if (currentOutline != null)
                    {
                        currentOutline.enabled = false; // ���� ������Ʈ�� �ƿ����� ��Ȱ��ȭ
                    }
                    currentOutline = outline;
                    currentOutline.enabled = true; // ���� ������Ʈ�� �ƿ����� Ȱ��ȭ
                }
            }
            else
            {
                if (currentOutline != null)
                {
                    currentOutline.enabled = false;
                    currentOutline = null;
                }
            }
        }
        else
        {
            // ���̾ �浹���� ���� ���
            lineRenderer.enabled = false;

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

            // ���� �ƿ����� �ʱ�ȭ
            if (currentOutline != null)
            {
                currentOutline.enabled = false;
                currentOutline = null;
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
}
