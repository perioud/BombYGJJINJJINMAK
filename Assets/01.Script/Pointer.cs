using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public Transform raycastOrigin; // 레이 시작 지점
    public OVRInput.Controller controller;
    public LineRenderer lineRenderer;
    public Color noHitColor = Color.red; // 레이가 닿지 않았을 때 색상
    public Color hitColor = Color.green; // 레이가 닿았을 때 색상
    private Outline outline;
    public float raycastDistance;
    private RaycastHit hit;
    private Button currentButton; // 현재 충돌한 버튼
    private Toggle currentToggle; // 현재 충돌한 토글
    private Slider currentSlider; // 현재 충돌한 슬라이더
    private GameObject ItemUi; // 현재 충돌한 Item 오브젝트 // UI on /off

    void Start()
    {
        lineRenderer.startColor = noHitColor;
        lineRenderer.endColor = noHitColor;
    }

    void Update()
    {
        // 레이캐스트를 트리거 버튼 상태에 따라 활성화/비활성화
        if (OVRInput.Get(OVRInput.Button.Two, controller))
        {
            lineRenderer.enabled = true;
            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);
            int layerMask = LayerMask.GetMask("Grabbables", "UI");

            // 레이캐스트 충돌 감지
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layerMask))
            {
                Debug.Log("Hit an object: " + hit.collider.gameObject.name);

                lineRenderer.startColor = hitColor;
                lineRenderer.endColor = hitColor;
                Vector3 endPoint = transform.position + transform.forward * hit.distance;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, endPoint);

                // 만약 충돌한 오브젝트가 Button 컴포넌트를 가지고 있다면 클릭 처리
                Button button = hit.collider.gameObject.GetComponent<Button>();
                if (button != null)
                {
                    currentButton = button; // 현재 충돌한 버튼 업데이트
                }

                Toggle toggle = hit.collider.gameObject.GetComponent<Toggle>();
                if (toggle != null)
                {
                    currentToggle = toggle; // 현재 충돌한 토글 업데이트
                }

                Slider slider = hit.collider.gameObject.GetComponent<Slider>();
                if (slider != null)
                {
                    currentSlider = slider; // 현재 충돌한 슬라이더 업데이트
                }

                // "Item" 태그를 가진 오브젝트 감지 // UI on/off
                if (hit.collider.CompareTag("Item"))
                {
                    GameObject itemObject = hit.collider.gameObject;
                    if (ItemUi != itemObject)
                    {
                        if (ItemUi != null)
                        {
                            ItemUi.transform.GetChild(0).gameObject.SetActive(false);
                        }
                        ItemUi = itemObject;
                        ItemUi.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (ItemUi != null)
                    {
                        ItemUi.transform.GetChild(0).gameObject.SetActive(false);
                        ItemUi = null;
                    }
                }
            }
            else
            {
                // 레이어에 충돌하지 않은 경우
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + (transform.forward * raycastDistance));
                lineRenderer.startColor = noHitColor;
                lineRenderer.endColor = noHitColor;

                // 현재 버튼 초기화
                currentButton = null;
                currentToggle = null;
                currentSlider = null;

                // 현재 Item 초기화 // UI on/off
                if (ItemUi != null)
                {
                    ItemUi.transform.GetChild(0).gameObject.SetActive(false);
                    ItemUi = null;
                }
            }

            // 트리거 버튼을 눌렀을 때
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            {
                // 현재 충돌한 버튼이 있고 그 버튼이 활성화된 상태이면
                if (currentButton != null && currentButton.IsActive())
                {
                    // 버튼을 클릭
                    currentButton.onClick.Invoke();
                    Debug.Log("Clicked button: " + currentButton.gameObject.name);
                }

                if (currentToggle != null && currentToggle.IsActive())
                {
                    currentToggle.onValueChanged.Invoke(!currentToggle.isOn);
                    Debug.Log("Clicked toggle: " + currentToggle.gameObject.name);
                }

                // Slider 기능 구현은 필요에 따라 추가
            }
        }
        else
        {
            // 레이캐스트를 비활성화
            lineRenderer.enabled = false;

            // 현재 ItemUi 초기화 // UI on/off
            if (ItemUi != null)
            {
                ItemUi.transform.GetChild(0).gameObject.SetActive(false);
                ItemUi = null;
            }
        }
    }
}
