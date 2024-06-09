using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class LongGreb : MonoBehaviour
{
    private GameObject targetObject;
    private OVRGrabbable grabbedObject;
    private RaycastHit hit;
    public LayerMask farGreb;
    public float raytDistance;
    public OVRInput.Controller controller;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two, controller))
        {
            // ����ĳ��Ʈ�� �ٶ󺸰� �ִ� ������Ʈ�� ã���ϴ�
            if (targetObject == null)
            {
                int layerMask = LayerMask.GetMask("Grabbables");


                if (Physics.Raycast(transform.position, transform.forward, out hit, raytDistance, layerMask))
                {
                    if (hit.collider.GetComponent<OVRGrabbable>())
                    {
                        targetObject = hit.collider.gameObject;
                    }

                }
            }

            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))     //�׷� ������
            {
                grabbedObject = targetObject.GetComponent<OVRGrabbable>();
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                grabbedObject.transform.SetParent(transform);
                targetObject = null;
            }

            if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))   //������
            {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }

        }

    }
}
