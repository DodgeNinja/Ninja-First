using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : Interactable
{
    [SerializeField] int speed;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    protected override void Interact()
    {
        Debug.Log("Interactable with " + gameObject.name);
        Reder();
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

    void FrontRader()
    {
        if (transform.localScale.x > 0)
        {
            while(Mathf.Rad2Deg * transform.rotation.y <= 40)
                transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
        }

        if (transform.localScale.x < 0)
        {
            while(Mathf.Rad2Deg * transform.rotation.y >= -40)
                transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
        }
    }

    void BackRader()
    { 

    }
}
