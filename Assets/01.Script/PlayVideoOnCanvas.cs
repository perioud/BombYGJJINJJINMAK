using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideoOnCanvas : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    [SerializeField]
    private GameObject newsPlayer;

    private bool videoPrepared = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.prepareCompleted += VideoPrepared;

        Debug.Log("PlayVideoOnCanvas script started.");

        // VideoPlayer의 준비가 완료될 때까지 기다립니다.
        // 준비가 완료되면 비디오가 재생됩니다.
        if (videoPrepared)
        {
            videoPlayer.Play();
            Debug.Log("Video prepared. Playing...");
        }
    }

    void Update()
    {
        ToggleNewsPlayer();
    }

    void VideoPrepared(VideoPlayer vp)
    {
        videoPrepared = true;
    }

    void ToggleNewsPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (newsPlayer.transform.GetChild(0).gameObject.activeSelf)
            {
                newsPlayer.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                newsPlayer.transform.GetChild(0).gameObject.SetActive(true);
            }

        }
    }
}
