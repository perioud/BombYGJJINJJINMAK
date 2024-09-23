using Oculus.Interaction;
using UnityEngine;

public class HandMaterial : MonoBehaviour
{
    public InteractorActiveState interactorState; // 인터랙터의 활성 상태
    public OVRInput.Controller controller;       // Oculus 컨트롤러 
    public Material material1;                   // 변경 전 머티리얼
    public Material material2;                   // 변경 후 머티리얼
    private Renderer handRenderer;              

    void Start()
    {

        handRenderer = GetComponent<Renderer>();

        // 시작 시 material1으로 설정
        if (handRenderer != null)
        {
            handRenderer.material = material1;
        }
    }

    void Update()
    {
        // 인터랙터가 활성화되었는지 확인
        bool isHandActive = interactorState.Active;

        if (isHandActive && handRenderer.material != material2)
        {
            // 활성화되면 material2로 변경
            handRenderer.material = material2;
        }
        else if (!isHandActive && handRenderer.material != material1)
        {
            // 비활성화되면 material1로 변경
            handRenderer.material = material1;
        }
    }
}
