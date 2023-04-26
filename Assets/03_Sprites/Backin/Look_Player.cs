using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look_Player : Singleton<NPCtalking>
{
    Im im;
    public bool interaction = false;

    NPCtalking nPC_Talk;
    protected override void Awake()
    {
        im = FindObjectOfType<Im>();
        nPC_Talk = GetComponent<NPCtalking>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //im.interaction = true;
            
            Vector3 look = other.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(new Vector3(look.x, 0, look.z) * Time.deltaTime);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            im.interaction = true;
            NPCtalking.instance.Lookplayer = true;
            other.GetComponent<Player_NPC_Talk>().CurrentNPCTALKTYPE = nPC_Talk._npc_talk;
          

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            NPCtalking.instance.Lookplayer = false;
            im.interaction = false;
            
        


        }
    }


}
