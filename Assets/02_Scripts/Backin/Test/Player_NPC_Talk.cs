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

    private string nope = "이 NPC와는 이미 대화 했습니다.";

    private bool talking = false;
    void Update()
    {
        if (NPCtalking.instance.Lookplayer == true) //NPC가 나를 보고있다면
        {
            if (talking == false)
            {
                if (Input.GetKeyDown(KeyCode.E)) //E를 눌렀다면
                {

                    text.text = "";
                    Cursor.lockState = CursorLockMode.Confined; //카메라 고정을 풀어주고
                    Cursor.visible = true; //마우스 포인터를 보여준다
                    talking = true;
                    switch (CurrentNPCTALKTYPE)//닿은놈의 이넘
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

                                NpcText(NPC_Text3[0], cool3);
                                Debug.Log("실행이 되니?");
                            }
                            else
                                StartCoroutine(Npc_End());
                            break;
                      
                    }
                }
            }

        }
        else// NPC가 나를 안보고 있다면
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
        textPanel.SetActive(true); //대화창 키기
        //text.text = npc_text;
        switch (npc_end)
        {
            case 0:
                cool0++;
                Debug.Log("실행이 되는구나?1");
                StartCoroutine(chartext(npc_text, 1));
                break;
            case 1:
                cool1++;
                StartCoroutine(chartext(npc_text, 2));
                break;
            case 2:
                cool2++;
                StartCoroutine(chartext(npc_text, 3));
                break;
            case 3:
                cool3++;
                StartCoroutine(chartext(npc_text, 4));
                break;
        }
    }

    IEnumerator chartext(string chat, int npc_end)
    {
        
        for (int i = 0; i <= chat.Length; i++)
        {
            text.text = chat.Substring(0, i);
            yield return new WaitForSeconds(0.09f);
        }
        switch (npc_end)
        {
            case 1:
                choice_DefaultTeacher.SetActive(true);
                break;
            case 2:
                choice_trader.SetActive(true);
                break;
            case 3:
                choice_PhysicsTeacher.SetActive(true);
                break;
            case 4:
                choice_gay.SetActive(true);
                break;
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
