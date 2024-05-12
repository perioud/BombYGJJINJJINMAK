using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    //public float lineSize = 16f;
    public Transform raycastOrigin; // 레이 시작 지점
    public OVRInput.Controller controller;
    public LineRenderer lineRenderer;
    public Color noHitColor = Color.red; // 레이가 닿지 않았을 때 색상
    public Color hitColor = Color.green; // 레이가 닿았을 때 색상
    private Outline outline;
    public float raycastDistance;
    private RaycastHit hit;
    private Button currentButton; // 현재 충돌한 버튼
    private Toggle currentToggle; // 현재 충돌한 토글
    private Slider currentSlider; // 현재 충돌한 슬라이더

    //[SerializeField]
    //TextProperty[] itemToolTips;        //_itemToolTipTextPerent에서 GetComponentsInChildrun을 통해
    //                                    //TextProperty를 List로 저장하기 위한 변수 (중요)
    //[SerializeField]
    //private GameObject _itemToolTipTextPerent;      //TextProperty Class를 가지고 있는 오브젝트를 참조하기 위해
    //                                                //아이템 오브젝트 부모를 지정하기위한 변수(중요)
    //private bool isHit;
    //[SerializeField]
    //private GameObject inventory;   //인벤토리

    //[SerializeField]
    //private ItemProperty lastHitItem = null;
    // public List<ItemProperty> itemProperties; //아이템 저장



    void Start()
    {

        lineRenderer.startColor = noHitColor;
        lineRenderer.endColor = noHitColor;

        // itemProperties = new List<ItemProperty>();
        //  itemToolTips = new List<TextProperty>();
    }

    void Update()
    {

        // 레이캐스트를 트리거 버튼 상태에 따라 활성화/비활성화
        if (OVRInput.Get(OVRInput.Button.Two, controller))
        {

            lineRenderer.enabled = true;
            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);
            int layerMask = LayerMask.GetMask("Grabbables", "UI");

            // 레이캐스트 충돌 감지
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layerMask))
            {
                Debug.Log("Hit an object: " + hit.collider.gameObject.name);


                lineRenderer.startColor = hitColor;
                lineRenderer.endColor = hitColor;
                Vector3 endPoint = transform.position + transform.forward * hit.distance;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, endPoint);

                // 만약 충돌한 오브젝트가 Button 컴포넌트를 가지고 있다면 클릭 처리
                Button button = hit.collider.gameObject.GetComponent<Button>();
                if (button != null)
                {
                    currentButton = button; // 현재 충돌한 버튼 업데이트
                }
                // 아웃라인 스크립트를 찾아 활성화
                outline = hit.collider.gameObject.GetComponent<Outline>();
                if (outline != null)
                {
                    outline.enabled = true;
                }

                Toggle toggle = hit.collider.gameObject.GetComponent<Toggle>();
                if (toggle != null)
                {
                    currentToggle = toggle; // 현재 충돌한 버튼 업데이트
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
                // 레이어에 충돌하지 않은 경우
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + (transform.forward * raycastDistance));
                lineRenderer.startColor = noHitColor;
                lineRenderer.endColor = noHitColor;
                

                // 현재 버튼 초기화
                currentButton = null;

                // 아웃라인 스크립트 비활성화
                if (outline != null)
                {
                    outline.enabled = false;
                    outline = null;
                }
            }

            // 트리거 버튼을 눌렀을 때
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                // 현재 충돌한 버튼이 있고 그 버튼이 활성화된 상태이면
                if (currentButton != null && currentButton.IsActive())
                {
                    // 버튼을 클릭
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
            // 레이캐스트를 비활성화
            lineRenderer.enabled = false;
            //lineRenderer.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            // 아웃라인 스크립트 비활성화
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
    //    if (hit.transform.tag == "Item")        //item 태그를 가지고 있는 것만 인지
    //    {
    //        //item오브젝트의 itemProperty 스크립트를 참조
    //        _itemToolTipTextPerent = hit.transform.parent.gameObject;     //레이캐스트를 통해 충돌한 오브젝트의 부모를 가져오고, 그 부모 오브젝트의 자식 중에서 두 번째 자식을 가져옴
    //        itemToolTips = _itemToolTipTextPerent.transform.GetChild(1).GetComponentsInChildren<TextProperty>(); //두 번째 자식 오브젝트 아래에 있는 모든 TextProperty 컴포넌트를 가져와서 리스트로 변환

    //        //for (int i = 0; i < itemToolTips.Count; i++)        //itemToolTips리스트에 있는 모든 속성을 가져와 추가
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
    //        itemToolTips[0].ToolTipText.text = item.itemName;       //Item Name이 먼저
    //        itemToolTips[1].ToolTipText.text = item.itemCommentry;  //두번째
    //        Debug.Log("아이템이름 : " + item.itemName
    //                    + '\n' + "아이템타입 : " + item.itemType); //Consol창 확인용
    //    }



    //}

}