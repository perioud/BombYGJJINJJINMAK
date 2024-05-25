using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVR : MonoBehaviour
{

    public GameObject Inventory;
    public GameObject Anchor;
    [Range(0f, -5f)]
    public float posZ;
    bool UIActive;

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            UIActive = !UIActive;
            Inventory.SetActive(UIActive);
        }
        if (UIActive)
        {
            Inventory.transform.position = new Vector3(Anchor.transform.position.x, Anchor.transform.position.y, Anchor.transform.position.z + posZ);
          // Inventory.transform.eulerAngles = new Vector3(-90, Inventory.transform.eulerAngles.y, -30);
        }
    }
}