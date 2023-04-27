using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcButtonExit : Singleton<NPCtalking>
{
    [SerializeField] GameObject choice;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NPCtalking.instance.selection_window == true)//그 NPC가 플레이어를 보고있고 E를 눌렀을때
        {
            if (Input.GetMouseButtonUp(0))
            {
                choice.SetActive(false);
               
                NPCtalking.instance.selection_window = false;
            }

        }
    }
}
