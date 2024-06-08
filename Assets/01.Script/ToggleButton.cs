using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Toggle toggle;
    public GameObject targetObject;
    public GameObject targetObject2;
    public AudioSource audioSource;

    private void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
        audioSource = GetComponent<AudioSource>();
    }

    public void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("ON");
            targetObject.SetActive(true);
            targetObject2.SetActive(true);
            audioSource.Play();
        }
        else
        {
            Debug.Log("OFF");
            targetObject.SetActive(false);
            targetObject2.SetActive(false);
        }
    }
}
