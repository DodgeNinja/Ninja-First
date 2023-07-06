using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Active : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    float radius = 1;

    void Update()
    {
        if (Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Player")).Length > 0)
        {
            Inventory inventory = FindObjectOfType<Inventory>();

            inventory.PlusItem(itemData);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Inventory inventory = FindObjectOfType<Inventory>();

            inventory.PlusItem(itemData);
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
