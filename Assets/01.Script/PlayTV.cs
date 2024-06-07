using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayTV : MonoBehaviour
{

    private IActiveState ActiveState { get; set; }

    public OVRInput.Controller controller;

    private VideoPlayer videoPlayer;
    [SerializeField]
    private GameObject newsPlayer;

    private bool videoPrepared = false;
    public GameObject Arrow;

    void Start()
    {
        
        ActiveState = FindObjectOfType<InteractorActiveState>();

        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.prepareCompleted += VideoPrepared;

        Debug.Log("PlayVideoOnCanvas script started.");

        
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

        bool isActive = ActiveState.Active;
        if(isActive == true)
        {
            Arrow.SetActive(false);
            if (OVRInput.GetDown(OVRInput.Button.One, controller))
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
        //else
        //{
        //    Arrow.SetActive(true);
        //}

    }

}
