using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;



public class Player_NPC_Talk : Singleton<NPCtalking>
{

    

    [SerializeField] GameObject textPanel;
    [SerializeField] GameObject choice_NPC;
    [SerializeField] GameObject choice_trader;
    [SerializeField] GameObject choice_teacher;
    [SerializeField] GameObject choice_gay;

   
    public TMP_Text text;
    public string[] NPC_Text1;
    public string[] NPC_Text2;
    public string[] NPC_Text3;
    public string[] NPC_Text4;

    public NPC_talk CurrentNPCTALKTYPE;

    private bool cool1 = false;
    private bool cool2 = false;
    private bool cool3 = false;
    private bool cool4 = false;

    private string a = "이 NPC와는 이미 대화 했습니다.";
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCtalking.instance.Lookplayer == true) //NPC가 나를 보고있다면
        {
          
            if (Input.GetKeyDown(KeyCode.E)) //E를 눌렀다면
            {
              
                text.text = "";
                Cursor.lockState = CursorLockMode.Confined; //카메라 고정을 풀어주고
                Cursor.visible = true; //마우스 포인터를 보여준다
               
                switch (CurrentNPCTALKTYPE)//닿은놈의 이넘
                {
                    //1
                    case NPC_talk.NPC:
                        if (cool1 == false)
                        {
                            NpcText(NPC_Text1[0],cool1);                      
                        }
                        else
                            StartCoroutine(Npc_End());
                        break;
                    //2
                    case NPC_talk.NPC_trader:
                        if (cool2 == false)
                        {
                            NpcText(NPC_Text2[0],cool2);                     
                        }
                        else
                            StartCoroutine(Npc_End());
                        break;
                    //3
                    case NPC_talk.NPC_teacher:
                        if(cool3 == false)
                        {
                        NpcText(NPC_Text3[0],cool3);                 
                        }
                       else
                            StartCoroutine(Npc_End());
                        break;
                    //4
                    case NPC_talk.NPC_gay:
                        if (cool4 == false)
                        {
                            NpcText(NPC_Text4[0], cool4);
                        }
                        else
                            StartCoroutine(Npc_End());
                        break;

                }
            }

        }
        else// NPC가 나를 안보고 있다면
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            textPanel.SetActive(false);
            text.text = "";

        }

    }

    private void NpcText(string npc_text, bool npc_end)
    {
        textPanel.SetActive(true); //대화창 키기
        //text.text = npc_text;
        if (npc_end == cool1)
        {
            cool1 = true;
            StartCoroutine(chartext(npc_text, "NPC1"));
        }
        else if(npc_end == cool2)
        {
            cool2 = true;
            StartCoroutine(chartext(npc_text, "NPC2"));
        }
        else if(npc_end == cool3)
        {
            cool3 = true;
            StartCoroutine(chartext(npc_text, "NPC3"));
        }
        else if(npc_end == cool4)
        {
            cool4 = true;
            StartCoroutine(chartext(npc_text, "NPC4"));
        }
        
        
    }

     IEnumerator chartext(string dk,string dmd)
    {
        for (int i = 0; i <=dk.Length ; i++)
        {
            text.text = dk.Substring(0,i);
            yield return new WaitForSeconds(0.09f);
        }
        if(dmd == "NPC1")
        {
            choice_NPC.SetActive(true);
        }
        else if (dmd == "NPC2")
        {
         
            choice_trader.SetActive(true);
        }
        else if(dmd == "NPC3")
        {
            choice_teacher.SetActive(true);
        }
        else if(dmd == "NPC4")
        {
            choice_gay.SetActive(true);
        }
    }
    IEnumerator Npc_End()
    {
        textPanel.SetActive(true);
        for (int i = 0; i <= a.Length; i++)
        {
            text.text = a.Substring(0, i);
            yield return new WaitForSeconds(0.015f);
        }
    }
   
}
