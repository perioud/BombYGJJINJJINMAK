using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTSStart : MonoBehaviour
{
    public AudioSource tts;
    public AudioSource correct;

    void Start()
    {
        tts.Play();
        correct.Play();
    }
}
