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
        if (NPCtalking.instance.selection_window == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                choice.SetActive(false);
                NPCtalking.instance.selection_window = false;
            }

        }
    }
}
