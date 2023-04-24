using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float Speed = 10.0f;
    Vector3 moveDirector;
    float gr = -9.81f;//수동 중력
    [SerializeField] Transform Cam;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelocity;



    CharacterController ChrCon;
    private void Awake()
    {
       
        ChrCon = GetComponent<CharacterController>();

    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dkdlt = new Vector3(x, 0, z).normalized;//정규화는 필수 루트2 조심 //방향벡터

        if (dkdlt.magnitude >= 0.1f)// 어느 방향으로 움직이는지 확.인 
        {
            float targetAngle = Mathf.Atan2(dkdlt.x, dkdlt.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;//Atan2 는 x축과 0에서 시작x쉼표y쉼표에서 끝나는 벡터 사이의 각도를 반환하는 함수
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);//ref turnSmoothVelocity 목표 각도 변수
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;// Vector3.dorward를 곱하면 원하는 방향 얻을수 있음

            ChrCon.Move(moveDir.normalized * Speed * Time.deltaTime);//움직이는거
        }

        if (ChrCon.isGrounded == false)// 바닥이 없음 발*동 그레비티
        {
            moveDirector.y += gr * Time.deltaTime * Speed;// 중력
        }
        ChrCon.Move(moveDirector * Speed * Time.deltaTime);//움직이는거 

        if (ChrCon.isGrounded == true)
        {
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("tlqkf");
        }

    }
    private void FixedUpdate()
    {




    }


}
