using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI coll1Text;
    [SerializeField] private TextMeshProUGUI coll2Text;
    [SerializeField] private TextMeshProUGUI coll3Text;
    [Header("Value")]
    [SerializeField] private int collect1Max;
    [SerializeField] private int collect2Max;
    [SerializeField] private int collect3Max;
    [SerializeField] private int collectLength;
    private int coll1, coll2, coll3, maxLength;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        AllCollect();
    }

    private void AllCollect()
    {
        if (maxLength >= collectLength)
        {
            //엔딩스크립트 enable 켜주기
        }
    }

    public void CollectionLight()
    {
        GameObject[] collects = GameObject.FindGameObjectsWithTag("Collection");
        foreach (GameObject collect in collects)
        {
            collect.GetComponent<Collider>().transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }

    public void OnColl(Collection col)
    {
        switch (col)
        {
            case Collection.collect1:
                coll1++;
                coll1Text.text = $"Collect1 {coll1}/{collect1Max}";
                if (coll1 >= collect1Max)
                    maxLength++;
                break;
            case Collection.collect2:
                coll2++;
                coll2Text.text = $"Collect2 {coll2}/{collect2Max}";
                if (coll2 >= collect2Max)
                    maxLength++;
                break;
            case Collection.collect3:
                coll3++;
                coll3Text.text = $"Collect3 {coll3}/{collect3Max}";
                if (coll3 >= collect3Max)
                    maxLength++;
                break;
        }
    }
}
