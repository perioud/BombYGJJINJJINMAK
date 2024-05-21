using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public Slider slider;
    public Text unlockText;
    public float unlockThreshold = 0.9f; // 슬라이더 값이 0.9 이상일 때 잠금 해제
    public AudioSource unlockSound;

    void Start()
    {
        if (slider == null || unlockText == null)
        {
            Debug.LogError("Slider or UnlockText is not assigned.");
            return;
        }

        slider.onValueChanged.AddListener(OnSliderValueChanged);
        ResetSlider();
    }

    void OnSliderValueChanged(float value)
    {
        if (value >= unlockThreshold)
        {
            SliderUnlock();
        }
    }

    void SliderUnlock()
    {
        unlockText.text = "Unlocked!";
        if (unlockSound != null)
        {
            unlockSound.Play();
        }
    }

    void ResetSlider()
    {
        if (slider == null || unlockText == null)
        {
            Debug.LogError("Slider or UnlockText is not assigned.");
            return;
        }

        slider.value = 0;
        unlockText.text = "Slide to Unlock";
    }
}
