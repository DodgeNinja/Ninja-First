using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;



public class Player_NPC_Talk : Singleton<NPCtalking>
{
    [SerializeField] GameObject[] textPanel;
    [SerializeField] GameObject choice_DefaultTeacher;
    [SerializeField] GameObject choice_trader;
    [SerializeField] GameObject choice_PhysicsTeacher;
    [SerializeField] GameObject choice_gay;


    public TMP_Text[] text;
    public string[] NPC_Text0;
    public string[] NPC_Text1;
    public string[] NPC_Text2;
    public string[] NPC_Text3;

    public NPC_talk CurrentNPCTALKTYPE;

    private int cool0 = 0;
    private int cool1 = 1;
    private int cool2 = 2;
    private int cool3 = 3;

    private bool[] endQuiz = new bool[5];

    private string nope = "이 NPC와는 이미 대화 했습니다.";

    private bool talking = false;

    private void Start()
    {
        endQuiz[0] = false;
        endQuiz[1] = false;
        endQuiz[2] = false;
        endQuiz[3] = false;
    }

    void Update()
    {
        if (NPCtalking.instance.Lookplayer == true) //NPC가 나를 보고있다면
        {

            if (Input.GetKeyDown(KeyCode.E)) //E를 눌렀다면
            {
                Cursor.lockState = CursorLockMode.Confined; //카메라 고정을 풀어주고
                Cursor.visible = true; //마우스 포인터를 보여준다
                talking = true;
                switch (CurrentNPCTALKTYPE)//닿은놈의 이넘
                {
                    //1
                    case NPC_talk.NPC_DefaultTeacher:
                        if (!endQuiz[0])
                        {
                            Debug.Log(cool0);
                            text[0].text = "";
                            NpcText(NPC_Text0[0], cool0);
                        }
                        break;
                    //2
                    case NPC_talk.NPC_trader:
                        if (!endQuiz[1])
                        {
                            Debug.Log(cool1);
                            text[1].text = "";
                            NpcText(NPC_Text1[0], cool1);
                        }
                        break;
                    //3
                    case NPC_talk.NPC_PhysicsTeacher:
                        if (!endQuiz[2])
                        {
                            Debug.Log(cool2);
                            text[2].text = "";
                            NpcText(NPC_Text2[0], cool2);
                        }
                        //else
                        //    StartCoroutine(Npc_End());
                        break;
                    //4
                    case NPC_talk.NPC_gay:
                        if (!endQuiz[3])
                        {
                            Debug.Log(cool3);
                            text[3].text = "";
                            NpcText(NPC_Text3[0], cool3);
                        }
                        //else
                        //    StartCoroutine(Npc_End());
                        break;

                }

            }

        }
        else// NPC가 나를 안보고 있다면
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            offchoice();
            foreach(GameObject pal in textPanel)
                pal.SetActive(false);
            foreach (TMP_Text te in text)
                te.text = "";

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
        //text.text = npc_text;
        switch (npc_end)
        {
            case 0:
                
                Debug.Log("실행이 되는구나?1");
                textPanel[0].SetActive(true);
                StartCoroutine(chartext(npc_text, 1));
                break;
            case 1:
                
                textPanel[1].SetActive(true);
                StartCoroutine(chartext(npc_text, 2));
                break;
            case 2:
               
                textPanel[2].SetActive(true);
                StartCoroutine(chartext(npc_text, 3));
                break;
            case 3:
                
                textPanel[3].SetActive(true);
                StartCoroutine(chartext(npc_text, 4));
                break;
        }
    }

    IEnumerator chartext(string chat, int npc_end)
    {
        
        for (int i = 0; i <= chat.Length; i++)
        {
            text[npc_end - 1].text = chat.Substring(0,i)    ;
            yield return new WaitForSeconds(0.09f);
        }
        switch (npc_end)
        {
            case 1:
                Debug.Log("북딱");
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

    public IEnumerator Npc_End(int num)
    {
        endQuiz[num] = true;
        for (int i = 0; i <= nope.Length; i++)
        {
            text[num].text = nope.Substring(0, i);
            yield return new WaitForSeconds(0.015f);
        }
    }

}
