using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRInputManager : MonoBehaviour
{
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }




    private void ControllerInput()
    {
        //OVRInput의 주요 용도는 Get(), GetDown(), GetUp() 함수를 통해 컨트롤러의 입력 상태에 엑세스 하는 것
        // Get(): 컨트롤러의 현재 프레임의 입력 상태를 쿼리 (매 프레임마다 반복)
        // GetDown(): 현재 프레임의 컨트롤러가 눌렸는지를 쿼리
        // GetUp(): 현재 프레임의 컨트롤러가 떼졌는지를 쿼리

        // 컨트롤러의 입력값을 받아오는 방법
        // ex) OVRInput.Get~(OVRInput.Button.[버튼 이름].[컨트롤러])

        // OVRInput.Button : 패드, 터치, 그 외 컨트롤러의 모든 눌리는 버튼 (눌렸다, 안눌렸다) = Boolean
        // OVRInput.Touch : 컨트롤러의 터치 가능 버튼 = Boolean
        // OVRInput.NearTouch : 물리적 접촉 전에 컨트롤러에 사용자의 손이 가까워지면 보고 = Boolean
        // OVRInput.Axis1D : 실수(float)를 반환하는 1차원 컨트롤 (트리거 버튼)
        // OVRInput.Axis2D : Vector2 값을 반환하는 2차원 컨트롤 (조이스틱)

        // 입력 매핑 방식
        // 1.Vitual Mapping (Combined Controller : 결합된 컨트롤러 액세스)
        // 결합된 컨트롤러에 액세스하여 각각의 손에 따라 매핑을 진행하는 방식
        // 왼손과 오른손에 버튼 이름이 별도로 분리되어 있어 구분하기 좋으나, 오른쪽 컨트롤러만 인식되었을 때 왼쪽 컨트롤러의 입력값이 작동됨

        // 오른쪽 트리거 버튼을 눌렀을 때
        //if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        //{
        //    Debug.Log("오른쪽 트리거 버튼");
        //}

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        //{
        //    Debug.Log("왼쪽 트리거 버튼");
        //}

        //2. Virtual Mapping (Individual Controller : 개별 컨트롤러 액세스)
        // 각각의 컨트롤러에 개별적으로 액세스하여 바인딩하는 방식 (LTouch or RTouch)
        // 개별 액세스이기 때문에 컨트롤러 인식내용과 별개로 문제가 없음, 각각의 컨트롤러에 맞춰 코드를 작성해야 함

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        //{
        //    Debug.Log("오른쪽 트리거 버튼");
        //}

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        //{
        //    Debug.Log("왼쪽 트리거 버튼");
        //}

        //3. Raw Mapping 원시 매핑
        // 컨트롤러를 직접 노출하여 지정하는 방법
        // 각각의 컨트롤러의 버튼마다 고유 매핑을 바인딩하여 사용하는 방식

        //if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        //{

        //}

    }
}
