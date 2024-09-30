using System.Collections;
using UnityEngine;

public class TeleportFadeControlOculus : MonoBehaviour
{
    public ScreenFade screenFade;  // ScreenFade 스크립트 참조
    public OVRInput.Controller controller;

    private bool isTeleporting = false; // 텔레포트 중인지 여부

    private void Update()
    {
        // 조이스틱 위로 움직일 때 텔레포트 시작
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp, controller))
        {
            Debug.Log("텔레포트 지점 선택 시작");
            isTeleporting = true; // 텔레포트 지점 선택 시작
        }

        // 조이스틱에서 손을 뗄 때 텔레포트 완료
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp, controller) && isTeleporting)
        {
            StartCoroutine(OnTeleportEnd());
        }

        // 조이스틱 왼쪽으로 눌렀을 때 회전
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, controller))
        {
            isTeleporting = true;
            StartCoroutine(OnTeleportEnd());

        }
        // 조이스틱 오른쪽으로 눌렀을 때 회전
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, controller))
        {
            isTeleporting = true;
            StartCoroutine(OnTeleportEnd());
        }
    }


    // 텔레포트 완료 시 페이드 아웃
    private IEnumerator OnTeleportEnd()
    {
        Debug.Log("텔레포트 완료");
        screenFade?.FadeOut();

        // 페이드 아웃이 완료될 때까지 대기
        yield return new WaitUntil(() => !screenFade.IsFading);

        isTeleporting = false;
    }
}
