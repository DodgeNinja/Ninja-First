using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController: MonoBehaviour
{
    public GameObject player;
    public float xmove = 0;
    public float ymove = 0;
    public float distance = 1;
    public float Camspeed = 2.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 X���� ������ �Է°��� xmove ������ �����Ѵ�
        xmove += Input.GetAxis("Mouse X")*Camspeed;
        // ���콺 Y���� ������ �Է°��� ymove ������ �����Ѵ�(-=�� ����: +=���� �ϸ� ���콺�� ���� �ø��� ���� ���� �Ʒ��� ������ �Ʒ��� ���� ���ڿ�������.)
        ymove -= Input.GetAxis("Mouse Y")*Camspeed;

        // ���콺 x,y ���� �������� ���Ϸ����� ���ʹϾ����� ��ȯ�����ְ� �װſ� ���� ī�޶��� ������ �����Ѵ�
        transform.rotation = Quaternion.Euler(ymove, xmove, 0);
        // ī������ �ٶ󺸴� ������ z���̹Ƿ� z�� ������ ���͸� ���Ѵ�
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        // ī�޶� ��ġ = �÷��̾��� ��ġ - ī�޶� ȸ���� * (0,0,�Ÿ�)��µ� �� �𸣰ھ��..
        transform.position = player.transform.position - transform.rotation * reverseDistance;

    }
}
