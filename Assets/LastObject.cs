//using UnityEngine;

//public class LastObject : MonoBehaviour
//{
//    // �±׸� ���� ������Ʈ�� �ݶ��̴��� ����� �� ȣ��Ǵ� �޼���
//    void OnTriggerEnter(Collider other)
//    {
//        // other�� �ݶ��̴��� ���� ������Ʈ�� �ݶ��̴��� ��Ÿ���ϴ�
//        // �±װ� "LastObj"�� ���
//        if (other.CompareTag("OBJHat") || other.CompareTag("OBJClothes") || other.CompareTag("OBJMask") || other.CompareTag("OBJUmbrella"))
//        {
//            // ������Ʈ�� ��Ȱ��ȭ�մϴ�
//            other.gameObject.SetActive(false);
//        }
//    }
//}
using UnityEngine;

public class LastObject : MonoBehaviour
{
    // �±׸� ���� ������Ʈ�� �ݶ��̴��� ����� �� ȣ��Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);

        // other�� �ݶ��̴��� ���� ������Ʈ�� �ݶ��̴��� ��Ÿ���ϴ�
        // �±װ� "OBJHat"�� ���
        if (other.CompareTag("OBJHat") || other.CompareTag("OBJClothes") || other.CompareTag("OBJMask") || other.CompareTag("OBJUmbrella"))
        {
            Debug.Log("Matched tag: " + other.tag);
            // ������Ʈ�� ��Ȱ��ȭ�մϴ�
            other.gameObject.SetActive(false);
        }
    }
}
