using UnityEngine;

public class DeactivateOnCollision : MonoBehaviour
{
    // �±׸� ���� ������Ʈ�� �ݶ��̴��� ����� �� ȣ��Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        // other�� �ݶ��̴��� ���� ������Ʈ�� �ݶ��̴��� ��Ÿ���ϴ�
        // �±װ� "LastObj"�� ���
        if (other.CompareTag("OBJHat") || other.CompareTag("OBJClothes") || other.CompareTag("OBJMask") || other.CompareTag("OBJUmbrella"))
        {
            // ������Ʈ�� ��Ȱ��ȭ�մϴ�
            other.gameObject.SetActive(false);
        }
        //if (other.CompareTag("OBJClothes"))
        //{
        //    // ������Ʈ�� ��Ȱ��ȭ�մϴ�
        //    other.gameObject.SetActive(false);
        //}
        //if (other.CompareTag("OBJMask"))
        //{
        //    // ������Ʈ�� ��Ȱ��ȭ�մϴ�
        //    other.gameObject.SetActive(false);
        //}
        //if (other.CompareTag("OBJUmbrella"))
        //{
        //    // ������Ʈ�� ��Ȱ��ȭ�մϴ�
        //    other.gameObject.SetActive(false);
        //}
    }
}
