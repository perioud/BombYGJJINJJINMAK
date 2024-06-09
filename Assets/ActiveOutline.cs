using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOutline : MonoBehaviour
{
    // Start is called before the first frame update
    private IActiveState ActiveState { get; set; }
    private Outline outline;
    private IActiveState Hovering { get; set; }


    void Start()
    {
        ActiveState = FindObjectOfType<InteractorActiveState>();
        Hovering = FindObjectOfType<ActiveStateHovering>();
    }


    // Update is called once per frame
    void Update()
    {
        bool isActive = ActiveState.Active; 
        bool isHovering = Hovering.Active;
        if (isActive == true)
        {
            outline.enabled = false;
          
            //if (OVRInput.GetDown(OVRInput.Button.One, controller))
            //{
            //    if (newsPlayer.transform.GetChild(0).gameObject.activeSelf)
            //    {
            //        newsPlayer.transform.GetChild(0).gameObject.SetActive(false);
            //    }
            //    else
            //    {
            //       newsPlayer.transform.GetChild(0).gameObject.SetActive(true);
            //   }

            //}
        }
        if(isHovering == true)
        {
            outline.enabled = true;
        }
        //else
        //{
        //    outline.enabled = false;
        //}

    }
}
