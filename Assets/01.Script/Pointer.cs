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
    public float raycastDistance;
    private RaycastHit hit;
    private Button currentButton; // 현재 충돌한 버튼
    private Toggle currentToggle; // 현재 충돌한 토글
    private Slider currentSlider; // 현재 충돌한 슬라이더
    private GameObject ItemUi; // 현재 충돌한 Item 오브젝트 // UI on /off
    private Outline currentOutline; // 현재 충돌한 오브젝트의 아웃라인

    void Start()
    {
        lineRenderer.startColor = noHitColor;
        lineRenderer.endColor = noHitColor;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.enabled = false; // 처음에는 LineRenderer를 비활성화
                                     
    }

    void Update()
    {
        bool raycastHitSomething = false;

        // 항상 레이캐스트를 수행하지만 LineRenderer는 숨겨둠
        int layerMask = LayerMask.GetMask("Grabbables", "UI");

        // 레이캐스트 충돌 감지
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layerMask))
        {
            Debug.Log("Hit an object: " + hit.collider.gameObject.name);

            raycastHitSomething = true;
            lineRenderer.enabled = true;

            // 라인 렌더러의 끝점 설정
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
            if (hit.collider.CompareTag("Item") || (hit.collider.CompareTag("Fresh")))
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

            // 현재 충돌한 오브젝트의 아웃라인 처리
            Outline outline = hit.collider.gameObject.GetComponent<Outline>();
            if (outline != null)
            {
                if (currentOutline != outline)
                {
                    if (currentOutline != null)
                    {
                        currentOutline.enabled = false; // 이전 오브젝트의 아웃라인 비활성화
                    }
                    currentOutline = outline;
                    currentOutline.enabled = true; // 현재 오브젝트의 아웃라인 활성화
                }
            }
            else
            {
                if (currentOutline != null)
                {
                    currentOutline.enabled = false;
                    currentOutline = null;
                }
            }
        }
        else
        {
            // 레이어에 충돌하지 않은 경우
            lineRenderer.enabled = false;

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

            // 현재 아웃라인 초기화
            if (currentOutline != null)
            {
                currentOutline.enabled = false;
                currentOutline = null;
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
}
