using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        transform.LookAt(target.transform.position);
       // Debug.Log("Ÿ���� ���� ������ : " + target.transform.position);
    }
}
