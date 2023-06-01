using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collection
{
    collect1,
    collect2,
    collect3
}

public class CollectManager : MonoBehaviour
{
    public static CollectManager instance;

    float coll1;
    float coll2;
    float coll3;

    private void Awake()
    {
        instance = this;
    }

    public void OnColl(Collection col)
    {
        switch (col)
        {
            case Collection.collect1:
                coll1++;
                break;
            case Collection.collect2:
                coll2++;
                break;
            case Collection.collect3:
                coll3++;
                break;
        }
    }
}
