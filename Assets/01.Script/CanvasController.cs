using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image notesImage; // Notes Image
    public Canvas chapter2Canvas; // Chapter2 UI Canvas
    public Canvas BagCanvas;
    public AudioClip soundClip; // ����� ���� Ŭ��
    private AudioSource audioSource; // AudioSource ������Ʈ
    private bool isChapter2Shown = false; // Chapter2 Canvas�� �� ���� ǥ�õǵ��� �ϱ� ���� ���� ����

    void Start()
    {
        // AudioSource ������Ʈ�� �������ų� ���� �߰�
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Notes Image�� Ȱ��ȭ�Ǿ��� Chapter2 Canvas�� ���� ǥ�õ��� �ʾ��� ��
        if (notesImage.gameObject.activeSelf && !isChapter2Shown)
        {
            ShowChapter2Canvas();
        }
    }

    private void ShowChapter2Canvas()
    {
        chapter2Canvas.gameObject.SetActive(true); // Chapter2 Canvas�� Ȱ��ȭ
        BagCanvas.gameObject.SetActive(true);
        isChapter2Shown = true; // ���� ������ true�� �����Ͽ� �ٽ� ǥ�õ��� �ʵ��� ��

        // ���� Ŭ���� ���
        if (soundClip != null && audioSource != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}
