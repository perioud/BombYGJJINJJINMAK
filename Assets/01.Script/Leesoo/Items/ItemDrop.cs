using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    List<TextProperty> itemToolTips;        //_itemToolTipTextPerent에서 GetComponentsInChildrun을 통해
                                            //TextProperty를 List로 저장하기 위한 변수 (중요)

    [SerializeField]
    List<TMP_Text> textList;        //ItemDrop Class에서 textList는 [0]은 itemName[1]은 TextCommentory출력 (중요)

    [SerializeField]
    private GameObject _itemToolTipTextPerent;      //TextProperty Class를 가지고 있는 오브젝트를 참조하기 위해
                                                    //아이템 오브젝트 부모를 지정하기위한 변수(중요)

    private bool isHit;

    [SerializeField]
    private GameObject inventory;   //인벤토리

    [SerializeField]
    private float range; //습득 가능한 최대 거리

    private bool pickupHow = false; //습듭 가능시 false

    private RaycastHit hitinfo; //충돌체 정보 저장

    [SerializeField] //아이템 레이어에만 반응
    private LayerMask layerMask;

    [SerializeField]
    private ItemProperty lastHitItem = null;


    public List<ItemProperty> itemProperties; //아이템 저장

    private void Start()
    {
        itemProperties = new List<ItemProperty>();
        textList = new List<TMP_Text>();
        itemToolTips = new List<TextProperty>();
    }
    void Update()
    {
       
        Action();
    }

    private void Action()
    {

        CheckItem();
        if (Input.GetKeyDown(KeyCode.E))        //VR컨트롤러 키로 바꿔야함
        {
            CanPickup();
        }

    }
    private void CanPickup()
    {
        if (pickupHow)
        {
            if (hitinfo.transform != null)
            {
                // Debug.Log("획득");

                itemProperties.Add(hitinfo.transform.GetComponent<ItemProperty>()); //레이캐스트를 통해 충돌한 오브젝트에서 ItemProperty 컴포넌트를 가져와서 리스트에 추가
                hitinfo.transform.gameObject.SetActive(false);     
                InfoDisappear();
            }
        }
    }
    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitinfo, range, layerMask))
        {
            if (hitinfo.transform.tag == "Item")        //item 태그를 가지고 있는 것만 인지
            {
                //item오브젝트의 itemProperty 스크립트를 참조


                _itemToolTipTextPerent = hitinfo.transform.parent.transform.GetChild(1).gameObject;     //레이캐스트를 통해 충돌한 오브젝트의 부모를 가져오고, 그 부모 오브젝트의 자식 중에서 두 번째 자식을 가져옴
                itemToolTips = _itemToolTipTextPerent.GetComponentsInChildren<TextProperty>().ToList(); //두 번째 자식 오브젝트 아래에 있는 모든 TextProperty 컴포넌트를 가져와서 리스트로 변환

                for (int i = 0; i < itemToolTips.Count; i++)        //itemToolTips리스트에 있는 모든 속성을 가져와 추가
                {                                                   //ToolTipText ++
                    textList.Add(itemToolTips[i].ToolTipText);
                }
                IteminfoApeer(hitinfo.transform.GetComponent<ItemProperty>());
                lastHitItem = hitinfo.transform.GetComponent<ItemProperty>();

                //lastHitItem.OnText();
                hitinfo.transform.GetComponent<Outline>().enabled=true; //스크립트 껐다 키기
                isHit = true;
                    
            }
        }
        else
        {
            InfoDisappear();        //
            if (lastHitItem != null)
            {
                //lastHitItem.OffText();      //감지되지 않으면 Text끄기
                lastHitItem.transform.GetComponent<Outline>().enabled = false;      // 감지되지 않으면 아웃라인 끄기
            }
            isHit = false;
        }

    }
    private void IteminfoApeer(ItemProperty item)
    {
        if (!isHit)
        {
           
            textList[0].text = item.itemName;       //Item Name이 먼저
            textList[1].text = item.itemCommentry;  //두번째
            Debug.Log("아이템이름 : " + item.itemName
                        + '\n' + "아이템타입 : " + item.itemType); //Consol창 확인용
        }

        pickupHow = true;

    }
    private void InfoDisappear()
    {
        pickupHow = false;
        
    }

}