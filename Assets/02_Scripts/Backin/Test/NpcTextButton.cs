using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcTextButton : Singleton<NPCtalking>
{
    [SerializeField] TMP_Text tmp;
        
   
    public string[] Npc_choice1;
    public string[] Npc_choice2;
    public string[] Npc_choice3;

    protected override void Awake()
    {
        
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
        tmp.text = Npc_choice1[0];
        NPCtalking.instance.selection_window = true;

    }
    public void two()
    {
        tmp.text = Npc_choice2[0];
        NPCtalking.instance.selection_window = true;
    }

    public void three()
    {
        tmp.text = Npc_choice3[0];
        NPCtalking.instance.selection_window = true;
    }
}
