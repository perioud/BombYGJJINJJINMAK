using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    
    public GameObject Slot;
    private void OnTriggerEnter(Collider other)
    {

            // �浹�� ������Ʈ�� A ������Ʈ���� Ȯ��
            if (other.CompareTag("Inventory"))
            {
                
                // A ������Ʈ�� ù ��° �ڽ� ������Ʈ�� ��ũ��Ʈ ������Ʈ ��������
                Image imageComponent = Slot.transform.GetChild(0).GetChild(0).GetComponent<Image>();

                imageComponent.sprite = GetComponent<ItemProperty>().itemImage;

                gameObject.SetActive(false);
            }
        }

        
    }
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

   


//private void OnCollisionEnter(Collision collision)
//{
//    // �浹�� ������Ʈ�� ���� ������Ʈ���� Ȯ��
//    if (collision.gameObject.CompareTag("Inventory"))
//    {
//        Destroy(collision.gameObject);


//        Debug.Log("2");


//        //// ���� ������Ʈ�� ��ũ��Ʈ ������Ʈ ��������
//        //Bag aScript = collision.gameObject.GetComponent<Bag>();

//        //// ���� ������Ʈ�� ���� �̹��� ������Ʈ�� ���ο� ��������Ʈ �Ҵ��ϱ�
//        //Sprite newSprite = Resources.Load<Sprite>("NewImageSprite"); // ������ ��������Ʈ ���
//        //aScript.ChangeImage(newSprite);
//    }











//private void OnTriggerEnter(Collider other)
//{
//    if (other.gameObject.tag == "Inventory")
//    {
//        Debug.Log("11111111111111111");
//        Transform slotCanvas = other.gameObject.transform.Find("SlotCanvas");
//        Debug.Log("222222222222");
//        Transform[] childObjects = slotCanvas.GetComponentsInChildren<Transform>(true);
//        Debug.Log("33333333333333");
//        foreach (Transform child in childObjects)
//        {
//            Debug.Log("4444444444444");
//            if (child.CompareTag("ImageSprite"))
//            {

//                Image imageComponent = child.GetComponent<Image>();
//                if (imageComponent != null)
//                {
//                    // Image ������Ʈ�� ���
//                }
//            }
//        }
//    }
//}
//}

