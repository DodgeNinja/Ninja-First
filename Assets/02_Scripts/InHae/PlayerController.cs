using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public GameObject Cam;
    private CharacterController controller;
    private Vector3 MoveDir;

    void Start()
    {
        speed = 5.0f;
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    { 
        // 플레이어의 움직임 x,z값 변수
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // 만약 x,z값이 0이 아니라면 즉 움직일 경우
        if (x != 0 || z != 0)
        {
            // 오프셋은 카메라가 바라보는 앞방향
            var offset = Cam.transform.forward;
            // 정면을 똑바로 바로 보기 위해 y축을 0으로
            offset.y = 0;
            // LookAt으로 플레이어의 포지선에 오프셋을 더해 정면을 바라보게함
            transform.LookAt(controller.transform.position + offset);
        }
        // x,z값 변수로 움직임 변수
        MoveDir = new Vector3(x, 0, z);
        // 플레이어가 바라보는 앞방향으로 이동방향을 돌려서 조정    
        MoveDir = controller.transform.TransformDirection(MoveDir);
        // 컨트롤러 무브에 움직임 변수,time.deltatime,speed를 곱해서 움직임
        controller.Move(MoveDir * Time.deltaTime * speed);
    }

}
