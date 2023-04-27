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
        if (NPCtalking.instance.Lookplayer == true)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                textPanel.SetActive(true);
                

                switch (CurrentNPCTALKTYPE)
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
                        Debug.Log("teacher");
                        text.text = NPC_Text3[0];

                        break;
                  
                }
            }
           
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            textPanel.SetActive(false);
            text.text = "";

        }

    }
}
