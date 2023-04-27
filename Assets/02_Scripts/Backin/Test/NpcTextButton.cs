using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcTextButton : Singleton<NPCtalking>
{
    [SerializeField] TMP_Text tmp;
    Transform player;

    public string[] Npc_choice1;//맨위 선택창
    public string[] Npc_choice2;//중간 선택칭
    public string[] Npc_choice3;//맨아래 선택창

    [SerializeField] GameObject food;
    [SerializeField] GameObject g;

    protected override void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region 기본NPC대화
    public void NPCnum1_NPC()
    {
        tmp.text = Npc_choice1[0];
        NPCtalking.instance.selection_window = true;

    }
    public void NPCnum2_NPC()
    {
        tmp.text = Npc_choice2[0];
        NPCtalking.instance.selection_window = true;
    }

    public void NPCnum3_NPC()
    {
        tmp.text = Npc_choice3[0];
        NPCtalking.instance.selection_window = true;
    }
    #endregion 끝

    #region 상인NPC대화
    public void NPCnum1_trader()
    {
        tmp.text = Npc_choice1[1];
        NPCtalking.instance.selection_window = true;
    }
    public void NPCnum2_trader()
    {
        tmp.text = Npc_choice2[1];
        NPCtalking.instance.selection_window = true;
    }
    public void NPCnum3_trader()
    {
        tmp.text = Npc_choice3[1];
        NPCtalking.instance.selection_window = true;
    }
    #endregion 끝

    #region 선생님NPC대화

    public void NPCnum1_teacher()
    {
        tmp.text = Npc_choice1[2];
        NPCtalking.instance.selection_window = true;
    }
    public void NPCnum2_teacher()
    {
        tmp.text = Npc_choice2[2];
        if (Random.Range(0, 101) <= 50)
        {

            GameObject fod = Instantiate(food);
            fod.transform.position = new Vector3(player.position.x, player.position.y+1, player.position.z + 1);
        }
        else
        {
            GameObject h = Instantiate(g);
            h.transform.position = new Vector3(player.position.x, player.position.y+1, player.position.z + 1);
        }
        NPCtalking.instance.selection_window = true;
    }
    public void NPCnum3_teacher()
    {
        tmp.text = Npc_choice3[2];
        NPCtalking.instance.selection_window = true;
    }
    #endregion 끝
}
