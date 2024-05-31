using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public GameObject NotesScreen;
    public GameObject Slot;
    int slotIndex;
    // 이미지를 변경하는 함수
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("Item"))
        {

            
            Image imageComponent = Slot.transform.GetChild(slotIndex).GetChild(0).GetComponent<Image>();
            
            imageComponent.sprite = other.gameObject.GetComponent<ItemProperty>().itemImage;
            Slot.transform.GetChild(slotIndex).GetChild(0).GetComponent<GetItemName>().inSlotItemName = other.gameObject.GetComponent<ItemProperty>().itemName;
            
            Color color = imageComponent.color;
            color.a = 1f;
            imageComponent.color = color;
            CompareItemCheckList(Slot.transform.GetChild(slotIndex).GetChild(0).GetComponent<GetItemName>().inSlotItemName);
            slotIndex++;
            other.gameObject.SetActive(false);
        }



    }
   
    private void CompareItemCheckList(string inSlotItemName)
    {
        
        for (int i = 1; i < NotesScreen.transform.childCount; i++)
        {   
            
            string checkListItemName = NotesScreen.transform.GetChild(i).GetComponent<GetItemName>().inSlotItemName;
            if (checkListItemName == inSlotItemName)
            {
                NotesScreen.transform.GetChild(i).GetComponent<Toggle>().isOn = true; break;
            }
            

        }
    }






    //if (other.gameObject.CompareTag("Item"))
    //{
    //    Transform slotCanvas = other.gameObject.transform.Find("SlotCanvas");

    //    Transform[] childObjects = slotCanvas.GetComponentsInChildren<Transform>(true);

    //    foreach (Transform child in childObjects)
    //    {
    //        if (child.CompareTag("ImageSprite"))
    //        {
    //            Debug.Log("11111111111111111");
    //            Image imageComponent = child.GetComponent<Image>();
    //            if (imageComponent != null)
    //            {
    //                // Image 컴포넌트를 사용하여 작업을 수행합니다.
    //            }
    //        }
    //    }


    //if (slotCanvas != null)
    //{
    //    // SlotCanvas의 자식들 중에서 Image 컴포넌트를 찾습니다.
    //    Image slots = slotCanvas.GetComponentInChildren<Image>();

    //    if (slots != null)
    //    {
    //        // 충돌한 오브젝트의 스프라이트를 이미지의 스프라이트로 변경합니다.
    //        Sprite itemSprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
    //        slots.sprite = itemSprite;

    //    }
    //}
    // }
    // }
    //public Sprite ItemImage;
    //private HashSet<Image> changedImages = new HashSet<Image>();

    //private void OnTriggerEnter(Collider other)
    //{
    //    // 충돌한 오브젝트가 Inventory 오브젝트인지 확인
    //    if (other.CompareTag("Inventory"))
    //    {
    //        Debug.Log("1");
    //        // Inventory 오브젝트에서 이름이 "Imagee"인 모든 Image 컴포넌트를 가져오기
    //        Image[] images = other.gameObject.GetComponentsInChildren<Image>()
    //            .Where(image => image.gameObject.name == "Imagee" && !changedImages.Contains(image))
    //            .ToArray();

    //        // 다음 Imagee에 할당하고 변경된 이미지 집합에 추가
    //        if (images.Length > 0)
    //        {
    //            images[0].sprite = ItemImage;
    //            changedImages.Add(images[0]);
    //        }
    //    }
    //    if (other.CompareTag("Inventory"))
    //    {
    //        // 충돌한 오브젝트가 thenorth일 때 자신을 비활성화
    //        gameObject.SetActive(false);
    //    }
    //}


    //    // 충돌한 오브젝트가 가방 오브젝트인지 확인
    //    if (collision.gameObject.CompareTag("Inventory"))
    //    {
    //        Destroy(collision.gameObject);


    //        Debug.Log("2");


    //        //// 가방 오브젝트의 스크립트 컴포넌트 가져오기
    //        //Bag aScript = collision.gameObject.GetComponent<Bag>();

    //        
    //        //Sprite newSprite = Resources.Load<Sprite>("NewImageSprite"); // 변경할 스프라이트 경로
    //        //aScript.ChangeImage(newSprite);
    //    }


}
