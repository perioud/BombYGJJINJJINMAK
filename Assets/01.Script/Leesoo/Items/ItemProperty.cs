using UnityEngine;

public class ItemProperty : MonoBehaviour
{
    [TextArea]
    public string itemCommentry;

    public string itemName; //아이템 이름

    public Sprite itemImage;// 아이템 이미지

    public ItemType itemType; //아이템 유형

    public bool isHit;
    public enum ItemType
    {
        Food,
        Water,
        Thing
    }

    //public void OnText() => gameObject.transform.GetChild(0).gameObject.SetActive(true);    //해당 게임 오브젝트의 첫번째 자식을 활성화
    //public void OffText() => gameObject.transform.GetChild(0).gameObject.SetActive(false);
    void Start()
    {
        //Age = 10;
        //Debug.Log(Age);
    }
}










//  public GameObject itemPre; //아이템의 프리팹

//public string ItemName
//{
//    get { return itemName; }
//    set { itemName = value; }
//}

//public Sprite ItemImage
//{
//    get { return itemImage; }
//    set
//    {
//        if (value != itemImage)
//        {
//            itemImage = value;
//        } else
//        {
//            return;
//        }
//    }
//}

//public int Age { get; set; }



//public string 