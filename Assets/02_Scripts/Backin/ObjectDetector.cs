using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{

    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> { } //�̺�Ʈ Ŭ���� ����
    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent(); //�̺�Ʈ Ŭ���� �ν���Ʈ ���� �� �޸� �Ҵ�

    [SerializeField] Camera mainCamera;//������ �����ϱ� ���� Camera
    [SerializeField] Ray ray;//������ ���� ���� ������ ���� Ray
    [SerializeField] RaycastHit hit; //������ �ε��� ������Ʈ ���� ������ ���� RaycastHit
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
        if (Input.GetMouseButtonDown(0))//���콺 ���� ��ư�� ������ ��
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //2D ����͸� ���� 3D ������ ������Ʈ�� ���콺�� �����ϴ� ���
            //���꿡 �ε����� ������Ʈ�� �����ؼ� hit�� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ButtonLayer))
            {

                if (ButCkl == false)
                {
                    ButCkl = true;
                    StartCoroutine(Button_Down()); //��ư �鰨


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
