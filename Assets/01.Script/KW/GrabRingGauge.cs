using Oculus.Interaction;
using UnityEngine;
using UnityEngine.UI;

public class GrabRingGauge : MonoBehaviour
{
    public Image ringGauge; // �� �������� ����� Image ������Ʈ
    public float fillSpeed = 0.7f; // �������� ä������ �ӵ�
    public float drainSpeed = 1.0f; // �������� �پ��� �ӵ�

    private float currentFill = 0f; // ���� ������ ���� (0 ~ 1 ���� ��)
    //private bool isPlayerInRange = false; // �÷��̾ ��� �ִ��� Ȯ���ϴ� ����
    private IActiveState ActiveState { get; set; }
    void Start()
    {
        ActiveState = FindObjectOfType<InteractorActiveState>();

    }
    void Update()
    {
        bool isActive = ActiveState.Active;

        // �÷��̾ ���� ���� ���� ���� ������ ó��
        if (isActive)
        {
            // �׷� ��ư�� ���� ������ �� ������ ä���
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                currentFill += fillSpeed * Time.deltaTime; // ä��� �ӵ��� ������ ����
                currentFill = Mathf.Clamp01(currentFill);  // 0 ~ 1 ���̷� �� ����
            }
            // ��ư�� ������ ������ �� ������ ���̱�
            else
            {
                currentFill -= drainSpeed * Time.deltaTime; // �پ��� �ӵ��� ������ ����
                currentFill = Mathf.Clamp01(currentFill);  // 0 ~ 1 ���̷� �� ����
            }
        }
        else
        {
            // �÷��̾ ���� �ۿ� ���� ���� �������� �پ��
            currentFill -= drainSpeed * Time.deltaTime; // �پ��� �ӵ��� ������ ����
            currentFill = Mathf.Clamp01(currentFill);  // 0 ~ 1 ���̷� �� ����
        }

        // �� ������ UI�� ���� �� �ݿ�
        ringGauge.fillAmount = currentFill;

        // �������� �� ���� ������Ʈ ��Ȱ��ȭ
        if (currentFill >= 1f)
        {
            gameObject.SetActive(false);
        }
    }

    // �÷��̾ ���� ������ ������ ��
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isPlayerInRange = true; // �÷��̾ ���� ���� ���� �� true
    //    }
    //}

    //// �÷��̾ ���� ������ ������ ��
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isPlayerInRange = false; // �÷��̾ ���� ������ ������ false
    //    }
    //}
}
