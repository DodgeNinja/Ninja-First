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
        //End();
    }

    public void End()
    {
        player.SetActive(false);
        animator.SetBool("Move", true);
    }
}
