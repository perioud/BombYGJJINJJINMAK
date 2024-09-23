using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Toggle toggle;
    public GameObject targetObject;
    public GameObject targetObject2;
    private AudioSource audioSource;
    public AudioClip soundClip; // 재생할 사운드 클립

    private void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
            Debug.Log("ON");
            targetObject.SetActive(true);
            targetObject2.SetActive(true);
        }
        else
        {
            Debug.Log("OFF");
            targetObject.SetActive(false);
            targetObject2.SetActive(false);
        }
    }
}
