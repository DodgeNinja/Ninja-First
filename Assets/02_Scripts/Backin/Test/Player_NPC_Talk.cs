using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_NPC_Talk : Singleton<NPCtalking>
{
    public NPC_talk CurrentNPCTALKTYPE;
    [SerializeField] GameObject textPanel;
    [SerializeField] GameObject choice_NPC;
    [SerializeField] GameObject choice_trader;
    [SerializeField] GameObject choice_teacher;
    public TMP_Text text;
    public string[] NPC_Text1;
    public string[] NPC_Text2;
    public string[] NPC_Text3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NPCtalking.instance.Lookplayer == true) //NPC�� ���� �����ִٸ�
        {

            if (Input.GetKeyDown(KeyCode.E)) //E�� �����ٸ�
            {

                Cursor.lockState = CursorLockMode.Confined; //ī�޶� ������ Ǯ���ְ�
                Cursor.visible = true; //���콺 �����͸� �����ش�
                textPanel.SetActive(true); //��ȭâ Ű��
                

                switch (CurrentNPCTALKTYPE)//�������� �̳�
                {
                    case NPC_talk.NPC:
                        choice_NPC.SetActive(true);
                        Debug.Log("NPC");
                        text.text = NPC_Text1[0];
                        break;

                    case NPC_talk.NPC_trader:
                        choice_trader.SetActive(true);
                        Debug.Log("trader");
                        text.text = NPC_Text2[0];

                        break;
                    case NPC_talk.teacher:
                        choice_teacher.SetActive(true);
                        Debug.Log("teacher");
                        text.text = NPC_Text3[0];

                        break;
                  
                }
            }
           
        }
        else// NPC�� ���� �Ⱥ��� �ִٸ�
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            textPanel.SetActive(false);
            text.text = "";

        }

    }
}
