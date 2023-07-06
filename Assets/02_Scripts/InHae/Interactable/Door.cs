using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : Interactable
{
    [SerializeField] int speed;

    private GameObject player;
    [SerializeField]
    private Animator animator;
    public bool isOpen = false;
    public bool isBackOpen = false;
    private Door[] doors = new Door[3];

    private void Awake()
    {
        doors = GetComponentsInChildren<Door>();
        player = GameObject.FindWithTag("Player");
    }

    protected override void Interact()
    {
        Debug.Log("Interactable with " + gameObject.name);

        Debug.Log(isOpen);
        if (isOpen)
        {
            Debug.Log("Close");
            Close();
        }
        else Reder();
    }


    void Reder()
    {
        Vector3 vec = player.transform.position - transform.position;
        if (Mathf.Acos(Vector3.Dot(vec.normalized, transform.forward)) * Mathf.Rad2Deg > 90)
        {
            FrontRader();
        }
        else
        {
            BackRader();
        }
    }

    void Close()
    {
        Vector3 vec = player.transform.position - transform.position;
        if (Mathf.Acos(Vector3.Dot(vec.normalized, transform.forward)) * Mathf.Rad2Deg > 90)
        {
            Debug.Log("ff");
            FrontClose();
        }
        else
        {
            Debug.Log("dd");
            BackClose();
        }
    }

    void FrontRader()
    {
        animator.SetBool("open", true);
    }

    void FrontClose()
    {
        animator.SetBool("open", false);
    }

    void BackRader()
    {
        animator.SetBool("backOpen", true);
    }

    void BackClose()
    {
        animator.SetBool("backOpen", false);
    }

    public void OpenSet()
    {
        foreach (Door door in doors) door.isOpen = true;
        foreach (Door door in doors) door.isBackOpen = true;
    }

    public void BackOpenSet()
    {
        foreach (Door door in doors) door.isBackOpen = true;
        foreach (Door door in doors) door.isOpen = true;
    }

    public void CloseSet()
    {
        foreach (Door door in doors) door.isOpen = false;
        foreach (Door door in doors) door.isBackOpen = false;
    }

    public void BackCloseSet()
    {
        foreach (Door door in doors) door.isBackOpen = false;
        foreach (Door door in doors) door.isOpen = false;
    }
}