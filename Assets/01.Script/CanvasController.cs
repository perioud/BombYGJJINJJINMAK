using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image notesImage; // Notes Image
    public Canvas chapter2Canvas; // Chapter2 UI Canvas
    public Canvas BagCanvas;
    public AudioClip soundClip; // 재생할 사운드 클립
    private AudioSource audioSource; // AudioSource 컴포넌트
    private bool isChapter2Shown = false; // Chapter2 Canvas가 한 번만 표시되도록 하기 위한 상태 변수

    void Start()
    {
        // AudioSource 컴포넌트를 가져오거나 새로 추가
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Notes Image가 활성화되었고 Chapter2 Canvas가 아직 표시되지 않았을 때
        if (notesImage.gameObject.activeSelf && !isChapter2Shown)
        {
            ShowChapter2Canvas();
        }
    }

    private void ShowChapter2Canvas()
    {
        chapter2Canvas.gameObject.SetActive(true); // Chapter2 Canvas를 활성화
        BagCanvas.gameObject.SetActive(true);
        isChapter2Shown = true; // 상태 변수를 true로 설정하여 다시 표시되지 않도록 함

        // 사운드 클립을 재생
        if (soundClip != null && audioSource != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}
