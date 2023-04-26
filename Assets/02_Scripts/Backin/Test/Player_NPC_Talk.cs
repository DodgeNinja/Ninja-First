using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_NPC_Talk : Singleton<NPCtalking>
{
    public NPC_talk CurrentNPCTALKTYPE;
    [SerializeField] GameObject textPanel;
    [SerializeField] GameObject choice;
    public TMP_Text text;
    public string[] NPC_Text;
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
                choice.SetActive(true);

                switch (CurrentNPCTALKTYPE)
                {
                    case NPC_talk.NPC0:
                        Debug.Log("NPC0");
                        text.text = NPC_Text[0];
                        break;

                    case NPC_talk.NPC1:
                        Debug.Log("NPC1");
                        text.text = NPC_Text[1];

                        break;
                    case NPC_talk.NPC2:
                        text.text = NPC_Text[2];

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
