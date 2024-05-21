using Oculus.Interaction;
using UnityEngine;

public class MainQuest1 : MonoBehaviour
{

    public InteractorActiveState leftInteractorState; // 왼손 인터랙터
    public InteractorActiveState rightInteractorState; // 오른손 인터랙터
    public OVRInput.Controller controller;
    public OVRScreenFade screenFade;

    void Start()
    {
        //interactorState = GetComponent<InteractorActiveState>(); // InteractorActiveState 컴포넌트 가져오기
        //if (interactorState == null)
        //{
        //    Debug.LogError("InteractorActiveState를 찾을 수 없습니다.");
        //    return;
        //}
    }

    void Update()
    {

        // 양 손 모두 활성화되어 있는지 확인
        bool isBothHandsActive = leftInteractorState.Active && rightInteractorState.Active;

        if (isBothHandsActive)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) ||
                OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                // 페이드 아웃 시작
                screenFade.FadeOut();
            }
        }
    }
}
