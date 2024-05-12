using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    float MovSpeed = 10f;
    CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector2 mov2d = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 mov = new Vector3(mov2d.x * Time.deltaTime * MovSpeed, 0f, mov2d.y * Time.deltaTime * MovSpeed);
        cc.Move(mov);
    }
}
