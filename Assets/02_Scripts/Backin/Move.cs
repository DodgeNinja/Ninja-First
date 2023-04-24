using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float Speed = 10.0f;
    Vector3 moveDirector;
    float gr = -9.81f;//���� �߷�
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
        Vector3 dkdlt = new Vector3(x, 0, z).normalized;//����ȭ�� �ʼ� ��Ʈ2 ���� //���⺤��

        if (dkdlt.magnitude >= 0.1f)// ��� �������� �����̴��� Ȯ.�� 
        {
            float targetAngle = Mathf.Atan2(dkdlt.x, dkdlt.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;//Atan2 �� x��� 0���� ����x��ǥy��ǥ���� ������ ���� ������ ������ ��ȯ�ϴ� �Լ�
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);//ref turnSmoothVelocity ��ǥ ���� ����
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;// Vector3.dorward�� ���ϸ� ���ϴ� ���� ������ ����

            ChrCon.Move(moveDir.normalized * Speed * Time.deltaTime);//�����̴°�
        }

        if (ChrCon.isGrounded == false)// �ٴ��� ���� ��*�� �׷���Ƽ
        {
            moveDirector.y += gr * Time.deltaTime * Speed;// �߷�
        }
        ChrCon.Move(moveDirector * Speed * Time.deltaTime);//�����̴°� 

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
