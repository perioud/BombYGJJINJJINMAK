using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        transform.LookAt(target.transform.position);
       // Debug.Log("타겟의 현재 포지션 : " + target.transform.position);
    }
}
