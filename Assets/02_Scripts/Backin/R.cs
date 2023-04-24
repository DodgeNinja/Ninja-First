using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R : MonoBehaviour
{
    public Transform m_tr; //트랜스폼을 담을 변수
    public float distance = 10.0f;  //레이 길이를 지정할 변수
    public RaycastHit hit; //충돌 정보를 가져올 레이케스트 히트
    public LayerMask m_layerMask = -1;  //레이어 마스크를 지정할 변수
    public RaycastHit[] hits;   //충돌 정보를 여러개 담을 레이케스트 히트 배열

    // Start is called before the first frame update
    void Start()
    {
        //트랜스폼을 받아온다
        m_tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        //레이 셋팅
        Ray ray = new Ray();
     


        //시작 지점 셋팅
        ray.origin = m_tr.position;

        //방향설정 m_tr의 forward 방향으로
        ray.direction = m_tr.forward;

        //하나만 검출 레이!

        //레이에 검출되는 것이 있다면(충돌이 되었다면)
        if (Physics.Raycast(ray))
        {
            
           
        }
        

        
    }
}

