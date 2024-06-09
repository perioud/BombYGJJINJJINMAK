//using UnityEngine;

//public class LastObject : MonoBehaviour
//{
//    // 태그를 가진 오브젝트가 콜라이더에 닿았을 때 호출되는 메서드
//    void OnTriggerEnter(Collider other)
//    {
//        // other는 콜라이더에 닿은 오브젝트의 콜라이더를 나타냅니다
//        // 태그가 "LastObj"인 경우
//        if (other.CompareTag("OBJHat") || other.CompareTag("OBJClothes") || other.CompareTag("OBJMask") || other.CompareTag("OBJUmbrella"))
//        {
//            // 오브젝트를 비활성화합니다
//            other.gameObject.SetActive(false);
//        }
//    }
//}
using UnityEngine;

public class LastObject : MonoBehaviour
{
    // 태그를 가진 오브젝트가 콜라이더에 닿았을 때 호출되는 메서드
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);

        // other는 콜라이더에 닿은 오브젝트의 콜라이더를 나타냅니다
        // 태그가 "OBJHat"인 경우
        if (other.CompareTag("OBJHat") || other.CompareTag("OBJClothes") || other.CompareTag("OBJMask") || other.CompareTag("OBJUmbrella"))
        {
            Debug.Log("Matched tag: " + other.tag);
            // 오브젝트를 비활성화합니다
            other.gameObject.SetActive(false);
        }
    }
}
