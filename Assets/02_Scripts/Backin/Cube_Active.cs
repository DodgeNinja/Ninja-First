using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Active : MonoBehaviour
{
    [SerializeField] ItemData itemData;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Inventory inventory = FindObjectOfType<Inventory>();

            inventory.PlusItem(itemData);
            gameObject.SetActive(false);
        }
    }
   
}
