using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 컨트롤러에 충돌한 다른 오브젝트를 컨트롤러에 종속시키는 기능 (위치, 회전 = TRansform)
// 컨트롤러로 3D 오브젝트를 잡는 기능

public class OVRInputController : MonoBehaviour
{
    //왼쪽, 오른쪽 컨트롤러를 구분하는 변수
    public OVRInput.Controller controller;

    // OVR CameraRig
    public Transform player;

    // Hand Anchor의 Transform과 Rigidbody
    private Transform handTransform = null;
    private Rigidbody handRigidbody = null;

    // 충돌체의 Rigidbody 저장하는 변수
    private Rigidbody attachedObject = null;

    //충돌한 충돌체들의 Rigidbody를 저장하는 변수
    private List<Rigidbody> contactRigidbodies = new List<Rigidbody>();

    void Start()
    {
        handTransform = GetComponent<Transform>();
        handRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 그립 버튼이 눌렸을 때, Pickup(오브젝트를 컨트롤러로 잡는 기능)이 실행되도록
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            ObjectPickup();
        }

        // 그립 버튼이 떼졌을 때, Drop(컨트롤러에 부착된 오브젝트를 떼는 기능)이 실행되도록
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            ObjectDrop();
        }


    }

    // 컨트롤러로 3D 오브젝트를 잡는 기능
    public void ObjectPickup()
    {
        attachedObject = GetNearestRigidbody();

        // attachedObject가 있다면 오브젝트를 컨트롤러에 종속시키는 기능 구현
        if (attachedObject == null)
            return;
        
        // 물체를 컨트롤러에 종속시킬 때, 중력을 비활성화
        attachedObject.useGravity = false;

        // [옵션] 물리효과를 비활성화
        attachedObject.isKinematic = true;


        attachedObject.transform.parent = handTransform; // 충돌한 오브젝트의 부모 오브젝트를 컨트롤러 변경 (종속&차일드화)
        attachedObject.transform.position = handTransform.position; //충돌한 오브젝트의 위치 초기화
        attachedObject.transform.rotation = handTransform.rotation; //충돌한 오브젝트의 회전 초기화
    }

    //컨트롤러에 충돌한 오브젝트 중 가장 가까운 거리에 있는 오브젝트의 Rigidbody를 저장하는 기능
    private Rigidbody GetNearestRigidbody()
    {
        //Rigidbody를 저장하는 임시 변수
        Rigidbody nearestRigidbody = null;

        //컨트롤러와 충돌체 사의 거리(Distance) 값을 저장하는 변수 (최소 값)
        float minDistance = float.MaxValue;

        // 현재 거리(Distance) 값을 저장하는 변수
        float distance = 0;

        //List에 저장된 Rigidbody 중 가장 가까운 Rigidbody를 판별하는 기능
        foreach (Rigidbody rigidbody in contactRigidbodies) 
        {
            //List에 저장된 Rigidbody 중 가까운 Rigidbody를 계산
            //rigidbody 충돌체의 위치와 handTransform(컨트롤러)의 사이의 거리를 계산
            distance = Vector3.Distance(rigidbody.transform.position, handTransform.position);


            // 현재 distance와 minDistance를 비교
            if (distance > minDistance)
            {
                //최소 거리 값을 갱신
                minDistance = distance;

                //반환할 가장 가까운 Rigidbody 객체를 저장
                nearestRigidbody = rigidbody;

            }


        }

        return nearestRigidbody;
    }



    // 컨트롤러에 부착된 3D 오브젝트를 떼는 기능
    public void ObjectDrop()
    {
        // 컨트롤러에 종속된 오브젝트가 있다면 오브젝트를 컨트롤러에서 떼도록 설정하는 기능 구현
        if (attachedObject == null)
            return;

        // 물체를 컨트롤러에 종속시킬 때, 중력을 활성화
        attachedObject.useGravity = true;

        // [옵션] 물리효과를 활성화
        attachedObject.isKinematic = false;

        attachedObject.transform.parent = null; // 충돌한 오브젝트의 부모 오브젝트를 원드로 변경 (차일드화 해제)

        // 컨트롤러에서 떼어짐과 동시에 컨트롤러가 가지고 있던 물리 에너지를 전달해주는 기능
        attachedObject.velocity += player.rotation * OVRInput.GetLocalControllerVelocity(controller);
        attachedObject.angularVelocity += player.rotation * OVRInput.GetLocalControllerAngularVelocity(controller);

        attachedObject = null;

    }

    // 컨트롤러에 3D 오브젝트를 부착하는 조건
    // 1. 컨트롤러의 버튼(Grip)을 누른다 (Input)
    // 2. 충돌이 가능해야 한다 (Collider, Rigidbody)
    // 3. 충돌체 간의 충돌이 일어나야 한다 (OnCollision~, OnTrigger)

    private void OnTriggerEnter(Collider other)
    {
        // 컨트롤러에 닿은 오브젝트의 태그가 InteractionObject 라면 attachedObject에 충돌체를 저장
        if (other.CompareTag("InteractionObject"))
        {
            // 컨트롤러에 닿은 충돌체가 있을 경우
            //attachedObject = other.gameObject.GetComponent<Rigidbody>();

            // List 배열에 충돌체를 저장
            contactRigidbodies.Add(other.gameObject.GetComponent<Rigidbody>());
        }



    }

    private void OnTriggerExit(Collider other)
    {
        // 컨트롤러에서 떼어진 오브젝트의 태그가 InteractionObject 라면 List에서 제거
        if (other.CompareTag("InteractionObject"))
        {
            //컨트롤러와 오브젝트의 충돌이 끝났을 때
            //attachedObject = null;

            //List 배열에서 충돌체를 삭제
            contactRigidbodies.Remove(other.gameObject.GetComponent<Rigidbody>());
        }

    }
}
