using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject[] item1;
    public GameObject[] item2;
    public List<GameObject> itemp2 = new List<GameObject>();
    public List<GameObject> itemp1 = new List<GameObject>();
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log(transform.position);
        for(int i = 0; i < 20; i++)
        {
            GameObject cake = Instantiate(item2[Random.Range(0, item2.Length)], Vector3.zero, Quaternion.identity, transform);
            cake.transform.position = transform.position;
            itemp2.Add(cake);
            cake.SetActive(false);
        }

     
        for(int i = 0; i < 20; i++)
        {
            GameObject Cola = Instantiate(item1[Random.Range(0, item1.Length)], Vector3.zero, Quaternion.identity, transform);
            Cola.transform.position = transform.position;
            itemp1.Add(Cola);
            Cola.SetActive(false);
            
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
