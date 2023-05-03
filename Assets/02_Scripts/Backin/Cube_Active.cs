using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Active : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    [SerializeField] Vector3 spwon;
   
    private void Awake()
    {
        transform.position = spwon;
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
   
}
