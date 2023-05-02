using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;



public class Player_NPC_Talk : Singleton<NPCtalking>
{
    [SerializeField] GameObject textPanel;
    [SerializeField] GameObject choice_DefaultTeacher;
    [SerializeField] GameObject choice_trader;
    [SerializeField] GameObject choice_PhysicsTeacher;
    [SerializeField] GameObject choice_gay;


    public TMP_Text text;
    public string[] NPC_Text0;
    public string[] NPC_Text1;
    public string[] NPC_Text2;
    public string[] NPC_Text3;

    public NPC_talk CurrentNPCTALKTYPE;

    private int cool0 = 0;
    private int cool1 = 1;
    private int cool2 = 2;
    private int cool3 = 3;

    private string nope = "�� NPC�ʹ� �̹� ��ȭ �߽��ϴ�.";
    void Update()
    {
        if (NPCtalking.instance.Lookplayer == true) //NPC�� ���� �����ִٸ�
        {

            if (Input.GetKeyDown(KeyCode.E)) //E�� �����ٸ�
            {

                text.text = "";
                Cursor.lockState = CursorLockMode.Confined; //ī�޶� ������ Ǯ���ְ�
                Cursor.visible = true; //���콺 �����͸� �����ش�

                switch (CurrentNPCTALKTYPE)//�������� �̳�
                {
                    //1
                    case NPC_talk.NPC_DefaultTeacher:
                        if (cool0 == 0)
                        {
                            NpcText(NPC_Text0[0], cool0);
                        }
                        else
                            StartCoroutine(Npc_End());
                        break;
                    //2
                    case NPC_talk.NPC_trader:
                        if (cool1 == 1)
                        {
                            NpcText(NPC_Text1[0], cool1);
                        }
                        else
                            StartCoroutine(Npc_End());
                        break;
                    //3
                    case NPC_talk.NPC_PhysicsTeacher:
                        if (cool2 == 2)
                        {
                            NpcText(NPC_Text2[0], cool2);
                        }
                        else
                            StartCoroutine(Npc_End());
                        break;
                    //4
                    case NPC_talk.NPC_gay:
                        if (cool3 == 3)
                        {
                            Debug.Log("������ �Ǵ�?");
                            NpcText(NPC_Text3[0], cool3);
                        }
                        else
                            StartCoroutine(Npc_End());
                        break;

                }
            }

        }
        else// NPC�� ���� �Ⱥ��� �ִٸ�
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            offchoice();
            textPanel.SetActive(false);
            text.text = "";

        }

    }

    private void offchoice()
    {
        choice_DefaultTeacher.SetActive(false);
        choice_trader.SetActive(false);
        choice_PhysicsTeacher.SetActive(false);
        choice_gay.SetActive(false);
    }

    private void NpcText(string npc_text, int npc_end)
    {
        textPanel.SetActive(true); //��ȭâ Ű��
        //text.text = npc_text;
        switch (npc_end)
        {
            case 0:
                cool0 += 1;
                Debug.Log("������ �Ǵ±���?1");
                StartCoroutine(chartext(npc_text, 1));
                break;
            case 1:
                cool1 += 1;
                StartCoroutine(chartext(npc_text, 2));
                break;
            case 2:
                cool2 += 1;
                StartCoroutine(chartext(npc_text, 3));
                break;
            case 3:
                cool3 += 1;
                StartCoroutine(chartext(npc_text, 4));
                break;

        }

        //if (npc_end == cool1)
        //{
        //    cool1 = true;
        //    Debug.Log("������ �Ǵ±���?1");
        //    StartCoroutine(chartext(npc_text, 1));
        //}
        //else if(npc_end == cool2)
        //{
        //    cool2 = true;
        //    StartCoroutine(chartext(npc_text, 2));
        //}
        //else if(npc_end == cool3)
        //{
        //    cool3 = true;
        //    StartCoroutine(chartext(npc_text, 3));
        //}
        //else if(npc_end == cool4)
        //{
        //    cool4 = true;
        //    Debug.Log("������ �Ǵ±���?4");
        //    StartCoroutine(chartext(npc_text, 4));
        //}


    }

    IEnumerator chartext(string dk, int dmd)
    {
        for (int i = 0; i <= dk.Length; i++)
        {
            text.text = dk.Substring(0, i);
            yield return new WaitForSeconds(0.09f);
        }
        if (dmd == 1)
        {

            choice_DefaultTeacher.SetActive(true);
        }
        else if (dmd == 2)
        {

            choice_trader.SetActive(true);
        }
        else if (dmd == 3)
        {
            choice_PhysicsTeacher.SetActive(true);
        }
        else if (dmd == 4)
        {
            Debug.Log("������ �Ǵ±���?!");
            choice_gay.SetActive(true);
        }
    }
    IEnumerator Npc_End()
    {
        textPanel.SetActive(true);
        for (int i = 0; i <= nope.Length; i++)
        {
            text.text = nope.Substring(0, i);
            yield return new WaitForSeconds(0.015f);
        }
    }

}
