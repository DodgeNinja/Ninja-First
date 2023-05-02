using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NPC_talk : short
{
    NPC_DefaultTeacher = 0,
    NPC_trader = 1,
    NPC_PhysicsTeacher = 2,
    NPC_gay = 3

}
public class NPCtalking : Singleton<NPCtalking>
{

    public bool Lookplayer = false;
    public NPC_talk _npc_talk;
    public bool NPC_talking = false;
    public bool selection_window = false;

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


}
