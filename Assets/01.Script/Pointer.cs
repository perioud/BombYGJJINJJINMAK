using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    //public float lineSize = 16f;
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

    //[SerializeField]
    //TextProperty[] itemToolTips;        //_itemToolTipTextPerent���� GetComponentsInChildrun�� ����
    //                                    //TextProperty�� List�� �����ϱ� ���� ���� (�߿�)
    //[SerializeField]
    //private GameObject _itemToolTipTextPerent;      //TextProperty Class�� ������ �ִ� ������Ʈ�� �����ϱ� ����
    //                                                //������ ������Ʈ �θ� �����ϱ����� ����(�߿�)
    //private bool isHit;
    //[SerializeField]
    //private GameObject inventory;   //�κ��丮

    //[SerializeField]
    //private ItemProperty lastHitItem = null;
    // public List<ItemProperty> itemProperties; //������ ����



    void Start()
    {

        lineRenderer.startColor = noHitColor;
        lineRenderer.endColor = noHitColor;

        // itemProperties = new List<ItemProperty>();
        //  itemToolTips = new List<TextProperty>();
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
                // �ƿ����� ��ũ��Ʈ�� ã�� Ȱ��ȭ
                outline = hit.collider.gameObject.GetComponent<Outline>();
                if (outline != null)
                {
                    outline.enabled = true;
                }

                Toggle toggle = hit.collider.gameObject.GetComponent<Toggle>();
                if (toggle != null)
                {
                    currentToggle = toggle; // ���� �浹�� ��ư ������Ʈ
                }

                Slider slider = hit.collider.gameObject.GetComponent<Slider>();
                if(slider != null)
                {
                    currentSlider = slider;
                }
                // CheckItem(hit);
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

                // �ƿ����� ��ũ��Ʈ ��Ȱ��ȭ
                if (outline != null)
                {
                    outline.enabled = false;
                    outline = null;
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
            }

            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                if(currentToggle != null && currentToggle.IsActive())
                {
                    currentToggle.onValueChanged.Invoke(true);
                    Debug.Log("Clicked toggle: " + currentToggle.gameObject.name);
                }
            }

            //if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            //{
            //    if(currentSlider != null && currentSlider.IsActive())
            //    {
            //        currentSlider.onValueChanged.Invoke();
            //        Debug.Log("Clicked toggle: " + currentToggle.gameObject.name);
            //    }
            //}
        }
        else
        {
            // ����ĳ��Ʈ�� ��Ȱ��ȭ
            lineRenderer.enabled = false;
            //lineRenderer.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            // �ƿ����� ��ũ��Ʈ ��Ȱ��ȭ
            if (outline != null)
            {
                outline.enabled = false;
                outline = null;
            }

            //if (lastHitItem != null)
            //{
            //    _itemToolTipTextPerent.transform.GetChild(1).gameObject.SetActive(false);
            //}
            //isHit = false;
        }

    }

    //private void CheckItem(RaycastHit hit)
    //{
    //    if (hit.transform.tag == "Item")        //item �±׸� ������ �ִ� �͸� ����
    //    {
    //        //item������Ʈ�� itemProperty ��ũ��Ʈ�� ����
    //        _itemToolTipTextPerent = hit.transform.parent.gameObject;     //����ĳ��Ʈ�� ���� �浹�� ������Ʈ�� �θ� ��������, �� �θ� ������Ʈ�� �ڽ� �߿��� �� ��° �ڽ��� ������
    //        itemToolTips = _itemToolTipTextPerent.transform.GetChild(1).GetComponentsInChildren<TextProperty>(); //�� ��° �ڽ� ������Ʈ �Ʒ��� �ִ� ��� TextProperty ������Ʈ�� �����ͼ� ����Ʈ�� ��ȯ

    //        //for (int i = 0; i < itemToolTips.Count; i++)        //itemToolTips����Ʈ�� �ִ� ��� �Ӽ��� ������ �߰�
    //        //{                                                   //ToolTipText ++
    //        //    textList.Add(itemToolTips[i].ToolTipText);
    //        //}
    //        _itemToolTipTextPerent.transform.GetChild(1).gameObject.SetActive(true);
    //        lastHitItem = hit.transform.GetComponent<ItemProperty>();
    //        IteminfoApeer(lastHitItem);

    //        isHit = true;

    //    }


    //}

    //private void IteminfoApeer(ItemProperty item)
    //{
    //    if (!isHit)
    //    {
    //        itemToolTips[0].ToolTipText.text = item.itemName;       //Item Name�� ����
    //        itemToolTips[1].ToolTipText.text = item.itemCommentry;  //�ι�°
    //        Debug.Log("�������̸� : " + item.itemName
    //                    + '\n' + "������Ÿ�� : " + item.itemType); //Consolâ Ȯ�ο�
    //    }



    //}

}