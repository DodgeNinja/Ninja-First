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
        // �÷��̾��� ������ x,z�� ����
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // ���� x,z���� 0�� �ƴ϶�� �� ������ ���
        if (x != 0 || z != 0)
        {
            // �������� ī�޶� �ٶ󺸴� �չ���
            var offset = Cam.transform.forward;
            // ������ �ȹٷ� �ٷ� ���� ���� y���� 0����
            offset.y = 0;
            // LookAt���� �÷��̾��� �������� �������� ���� ������ �ٶ󺸰���
            transform.LookAt(controller.transform.position + offset);
        }
        // x,z�� ������ ������ ����
        MoveDir = new Vector3(x, 0, z);
        // �÷��̾ �ٶ󺸴� �չ������� �̵������� ������ ����    
        MoveDir = controller.transform.TransformDirection(MoveDir);
        // ��Ʈ�ѷ� ���꿡 ������ ����,time.deltatime,speed�� ���ؼ� ������
        controller.Move(MoveDir * Time.deltaTime * speed);
    }

}
