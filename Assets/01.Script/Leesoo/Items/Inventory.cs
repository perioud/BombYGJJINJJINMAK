using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemProperty> _itemProperties; //ItemDrop 클래스에 있는 itemProperties를 복사

    public GameObject _inventory;

    public ItemDrop _itemDrop;

    private void Start()
    {
        _itemDrop = gameObject.transform.parent.GetComponent<ItemDrop>();
    }

    private void Update()
    {
        OnInventory();
    }
    void OnInventory()  //인벤토리 키고 끄기
    {
        if (Input.GetKeyDown(KeyCode.I))        
        {
            if (gameObject.transform.GetChild(0).gameObject.activeSelf)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                _itemProperties = _itemDrop.itemProperties;
                SlotSetting();
            }
        }
    }
    void SlotSetting()                  //렌더링 슬롯을 초기화 해서 렌더링 보류
    {
        foreach (ItemProperty asd in _itemProperties)
        {
            for (int i = 0; i < _inventory.transform.childCount; i++)
            {
                if (_inventory.transform.GetChild(i).GetComponent<Slot>()._isGetItem)
                {                   
                    //Slot에 아이템에 있다면, 똑같은 아이템이면 카운트를 증가시키고 아니면 다음 슬롯으로 반복 
                }
                else
                {
                    _inventory.transform.GetChild(i).GetComponent<Slot>().SlotSprite = asd.itemImage;
                    break;
                }          
            }
        }
    }
}
