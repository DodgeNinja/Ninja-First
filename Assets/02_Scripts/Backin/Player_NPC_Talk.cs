using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_NPC_Talk : Singleton<NPCtalking>
{
    public NPC_talk CurrentNPCTALKTYPE;
    [SerializeField] GameObject textPanel;
    [SerializeField] Text text;
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



                textPanel.SetActive(true);

                switch (CurrentNPCTALKTYPE)
                {
                    case NPC_talk.NPC0:
                        Debug.Log("NPC0");
                        text.text = "NPC0�Ӿƹ�ư �׷�";


                        break;
                    case NPC_talk.NPC1:
                        Debug.Log("NPC1");
                        text.text = "����������";

                        break;
                    case NPC_talk.NPC2:
                        text.text = "�ڸ�Ŭ ���Ƴ�";

                        break;
                    default:
                        Debug.Log("��������");
                        break;
                }




            }
        }
            else
            {
                textPanel.SetActive(false);
                text.text = "";

            }

    }
}
