using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R : MonoBehaviour
{
    public Transform m_tr; //Ʈ�������� ���� ����
    public float distance = 10.0f;  //���� ���̸� ������ ����
    public RaycastHit hit; //�浹 ������ ������ �����ɽ�Ʈ ��Ʈ
    public LayerMask m_layerMask = -1;  //���̾� ����ũ�� ������ ����
    public RaycastHit[] hits;   //�浹 ������ ������ ���� �����ɽ�Ʈ ��Ʈ �迭

    // Start is called before the first frame update
    void Start()
    {
        //Ʈ�������� �޾ƿ´�
        m_tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        //���� ����
        Ray ray = new Ray();
     


        //���� ���� ����
        ray.origin = m_tr.position;

        //���⼳�� m_tr�� forward ��������
        ray.direction = m_tr.forward;

        //�ϳ��� ���� ����!

        //���̿� ����Ǵ� ���� �ִٸ�(�浹�� �Ǿ��ٸ�)
        if (Physics.Raycast(ray))
        {
            
           
        }
        

        
    }
}

