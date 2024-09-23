using Oculus.Interaction;
using UnityEngine;

public class HandMaterial : MonoBehaviour
{
    public InteractorActiveState interactorState; // ���ͷ����� Ȱ�� ����
    public OVRInput.Controller controller;       // Oculus ��Ʈ�ѷ� 
    public Material material1;                   // ���� �� ��Ƽ����
    public Material material2;                   // ���� �� ��Ƽ����
    private Renderer handRenderer;              

    void Start()
    {

        handRenderer = GetComponent<Renderer>();

        // ���� �� material1���� ����
        if (handRenderer != null)
        {
            handRenderer.material = material1;
        }
    }

    void Update()
    {
        // ���ͷ��Ͱ� Ȱ��ȭ�Ǿ����� Ȯ��
        bool isHandActive = interactorState.Active;

        if (isHandActive && handRenderer.material != material2)
        {
            // Ȱ��ȭ�Ǹ� material2�� ����
            handRenderer.material = material2;
        }
        else if (!isHandActive && handRenderer.material != material1)
        {
            // ��Ȱ��ȭ�Ǹ� material1�� ����
            handRenderer.material = material1;
        }
    }
}
