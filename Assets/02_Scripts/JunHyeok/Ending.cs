using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [Header("Reference")]
    public GameObject player;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("Move", true);
            //End();
        }
    }

    private void End()
    {
        player.SetActive(false);
        
    }
}
