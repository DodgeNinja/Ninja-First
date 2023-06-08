using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Buton : MonoBehaviour
{
    Item item;
    int a = 0;
    int b = 0;
    private void Awake()
    {
        item = FindAnyObjectByType<Item>();
    }

    private void Update()
    {

    }
    public void ButDown()
    {
        Debug.Log("down");
        if (a > 19)
            a = 0;
        if (b > 19)
            b = 0;

        transform.position += Vector3.left * 0.02f;
        if (Random.Range(0, 101) <= 50)
        {
            item.itemp1[a].transform.position = transform.GetChild(0).position;
            item.itemp1[a].SetActive(true);
            a += 1;
        }
        else
        {
            item.itemp2[b].transform.position = transform.GetChild(0).position;
            item.itemp2[b].SetActive(true);
            b += 1;
        }

    }
    public void ButUp()
    {
        transform.position += Vector3.right * 0.02f;
      
    }


}
