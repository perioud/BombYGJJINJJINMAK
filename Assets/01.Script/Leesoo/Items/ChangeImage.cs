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

            // 충돌한 오브젝트가 A 오브젝트인지 확인
            if (other.CompareTag("Inventory"))
            {
                
                // A 오브젝트의 첫 번째 자식 오브젝트의 스크립트 컴포넌트 가져오기
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

   


//private void OnCollisionEnter(Collision collision)
//{
//    // 충돌한 오브젝트가 가방 오브젝트인지 확인
//    if (collision.gameObject.CompareTag("Inventory"))
//    {
//        Destroy(collision.gameObject);


//        Debug.Log("2");


//        //// 가방 오브젝트의 스크립트 컴포넌트 가져오기
//        //Bag aScript = collision.gameObject.GetComponent<Bag>();

//        //// 가방 오브젝트가 가진 이미지 컴포넌트에 새로운 스프라이트 할당하기
//        //Sprite newSprite = Resources.Load<Sprite>("NewImageSprite"); // 변경할 스프라이트 경로
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
//                    // Image 컴포넌트를 사용
//                }
//            }
//        }
//    }
//}
//}

