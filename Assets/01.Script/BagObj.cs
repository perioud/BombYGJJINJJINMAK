using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagObj : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    public GameObject Object7;
    public GameObject Object8;
    public GameObject Object9;
    public GameObject Object10;
    public GameObject Object11;
    public GameObject Object12;
    public GameObject Object13;
    public GameObject Object14;
    public GameObject Object15;
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;
    public GameObject UI5;
    public GameObject UI6;
    public GameObject UI7;
    public GameObject UI8;
    public GameObject UI9;
    public GameObject UI10;
    public GameObject UI11;

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (other.gameObject == Object1)
            {
                Debug.Log("Object Check");
                if (!UI1.activeSelf)
                {
                    UI1.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object2 || Object3)
            {
                Debug.Log("Object Check");
                if (!UI2.activeSelf)
                {
                    UI2.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object4 || Object5)
            {
                Debug.Log("Object Check");
                if (!UI3.activeSelf)
                {
                    UI3.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object6)
            {
                Debug.Log("Object Check");
                if (!UI4.activeSelf)
                {
                    UI4.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object7)
            {
                Debug.Log("Object Check");
                if (!UI5.activeSelf)
                {
                    UI5.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object8)
            {
                Debug.Log("Object Check");
                if (!UI6.activeSelf)
                {
                    UI6.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object9)
            {
                Debug.Log("Object Check");
                if (!UI7.activeSelf)
                {
                    UI7.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object10)
            {
                Debug.Log("Object Check");
                if (!UI8.activeSelf)
                {
                    UI8.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
        }
        else if (other.CompareTag("Fresh"))
        {
            if (other.gameObject == Object11 || Object12 || Object13)
            {
                Debug.Log("Object Check");
                if (!UI9.activeSelf)
                {
                    UI9.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object14)
            {
                Debug.Log("Object Check");
                if (!UI10.activeSelf)
                {
                    UI10.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
            else if (other.gameObject == Object15)
            {
                Debug.Log("Object Check");
                if (!UI11.activeSelf)
                {
                    UI11.SetActive(true);
                    StartCoroutine(HideUIAfterDelay());
                }
            }
        }
    }
    IEnumerator HideUIAfterDelay()
    {
        // uiDisplayDuration만큼 대기
        yield return new WaitForSeconds(5.0f);

        // UI 비활성화
        UI1.SetActive(false);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);
        UI5.SetActive(false);
        UI6.SetActive(false);
        UI7.SetActive(false);
        UI8.SetActive(false);
        UI9.SetActive(false);
        UI10.SetActive(false);
        UI11.SetActive(false);
    }
}
