using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable
{


    protected override void Interact()
    {
        Debug.Log("Interactable with " + gameObject.name);
        Destroy(gameObject);
    }
}
