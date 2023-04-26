using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;
using System;

public class Inventory : MonoBehaviour
{
    public Slot[] slots;
    [SerializeField] private ItemData itemData;

    private void Awake()
    {
        slots = FindObjectsOfType<Slot>();
        Array.Sort(slots, (b, a) =>
        {
            return a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex());
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlusItem(itemData);
        }
    }

    public void PlusItem(ItemData item)
    {
        //List<Slot> slotList = new List<Slot>();

        //foreach (Slot slot in slots)
        //    slotList.Add(slot);

        //slotList.Sort((a, b) => a.gameObject.transform.GetSiblingIndex()
        //.CompareTo(b.gameObject.transform.GetSiblingIndex()));
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == ItemEnum.Null)
            {
                slots[i].item = item.item;
                slots[i].itemSprite = item.itemSprite;
                break;
            }
        }
    }
}
