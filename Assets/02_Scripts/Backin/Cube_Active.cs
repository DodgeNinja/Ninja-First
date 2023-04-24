using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Active : MonoBehaviour
{
    [SerializeField] Vector3 spwon;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        transform.position = spwon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
