using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{

    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { } //이벤트 클래스 정의
    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent(); //이벤트 클래스 인스턴트 생성 및 메모리 할당

    [SerializeField] Camera mainCamera;//광선을 생성하기 위한 Camera
    [SerializeField] Ray ray;//생성된 광선 정보 저장을 위한 Ray
    [SerializeField] RaycastHit hit; //광선에 부딪힌 오브젝트 정보 저장을 위한 RaycastHit
    [SerializeField] LayerMask ButtonLayer;
    bool ButCkl = false;


    private void Awake()
    {

        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//마우스 왼쪽 버튼을 눌렀을 때
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //2D 모니터를 통해 3D 월드의 오브젝트를 마우스로 선택하는 방법
            //광산에 부딪히는 오브젝트를 검출해서 hit에 저장
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ButtonLayer))
            {

                if (ButCkl == false)
                {
                    ButCkl = true;
                    StartCoroutine(Button_Down()); //버튼 들감


                }

            }
        }
    }
  
    IEnumerator Button_Down()
    {
        Button Button = FindAnyObjectByType<Button>();
        Button.ButDown();
        yield return new WaitForSeconds(0.5f);
        Button.ButUp();
        ButCkl = false;
    }
}
