using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look_Player : MonoBehaviour
{
    
    public bool interaction = false;
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
            interaction = true;
            transform.LookAt(other.transform);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interaction = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            interaction = false;


        }
    }
}
