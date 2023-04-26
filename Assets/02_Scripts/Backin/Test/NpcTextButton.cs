using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcTextButton : Singleton<NPCtalking>
{
    TMP_Text tmp;
    [SerializeField] GameObject choice;
    Player_NPC_Talk player_npc_talk;
    public string[] Npc_choice1;
    public string[] Npc_choice2;
    public string[] Npc_choice3;

    protected override void Awake()
    {
        player_npc_talk = GetComponent<Player_NPC_Talk>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void one()
    {
      
        player_npc_talk.text.text = Npc_choice1[0];
        
        
       

    }
    public void two()
    {
        player_npc_talk.text.text = Npc_choice2[0];   
    }

    public void three()
    {
        player_npc_talk.text.text = Npc_choice3[0];
    }
}
