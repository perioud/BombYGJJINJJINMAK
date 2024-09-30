using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTest : MonoBehaviour
{
    // Start is called before the first frame update
    private IActiveState ActiveState { get; set; }
    void Start()

    {
        ActiveState = FindObjectOfType<InteractorActiveState>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isActive = ActiveState.Active;
        if (isActive)
        {
            Debug.Log("È°¼ºÈ­");
        }
    }
}
