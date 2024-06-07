using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTSStart : MonoBehaviour
{
    public AudioSource tts;
    void Start()
    {
        tts.Play();
    }
}
