using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public GameObject NotesScreen;
    public GameObject Slot;
    int slotIndex;
    // �̹����� �����ϴ� �Լ�
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
    //                // Image ������Ʈ�� ����Ͽ� �۾��� �����մϴ�.
    //            }
    //        }
    //    }


    //if (slotCanvas != null)
    //{
    //    // SlotCanvas�� �ڽĵ� �߿��� Image ������Ʈ�� ã���ϴ�.
    //    Image slots = slotCanvas.GetComponentInChildren<Image>();

    //    if (slots != null)
    //    {
    //        // �浹�� ������Ʈ�� ��������Ʈ�� �̹����� ��������Ʈ�� �����մϴ�.
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
    //    // �浹�� ������Ʈ�� Inventory ������Ʈ���� Ȯ��
    //    if (other.CompareTag("Inventory"))
    //    {
    //        Debug.Log("1");
    //        // Inventory ������Ʈ���� �̸��� "Imagee"�� ��� Image ������Ʈ�� ��������
    //        Image[] images = other.gameObject.GetComponentsInChildren<Image>()
    //            .Where(image => image.gameObject.name == "Imagee" && !changedImages.Contains(image))
    //            .ToArray();

    //        // ���� Imagee�� �Ҵ��ϰ� ����� �̹��� ���տ� �߰�
    //        if (images.Length > 0)
    //        {
    //            images[0].sprite = ItemImage;
    //            changedImages.Add(images[0]);
    //        }
    //    }
    //    if (other.CompareTag("Inventory"))
    //    {
    //        // �浹�� ������Ʈ�� thenorth�� �� �ڽ��� ��Ȱ��ȭ
    //        gameObject.SetActive(false);
    //    }
    //}


    //    // �浹�� ������Ʈ�� ���� ������Ʈ���� Ȯ��
    //    if (collision.gameObject.CompareTag("Inventory"))
    //    {
    //        Destroy(collision.gameObject);


    //        Debug.Log("2");


    //        //// ���� ������Ʈ�� ��ũ��Ʈ ������Ʈ ��������
    //        //Bag aScript = collision.gameObject.GetComponent<Bag>();

    //        
    //        //Sprite newSprite = Resources.Load<Sprite>("NewImageSprite"); // ������ ��������Ʈ ���
    //        //aScript.ChangeImage(newSprite);
    //    }


}
