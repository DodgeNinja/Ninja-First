using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class Inventory : MonoBehaviour
{
    public void PlusItem(ItemData item)
    {
        List<Slot> slotList = new List<Slot>();
        Slot[] slots = FindObjectsOfType<Slot>();

        foreach (Slot slot in slots)
            slotList.Add(slot);

        slotList.Sort((a, b) => a.gameObject.transform.GetSiblingIndex()
        .CompareTo(b.gameObject.transform.GetSiblingIndex()));

        for (int i = 0; i < slots.Length; i++)
        {
            if (slotList[i].item == ItemEnum.Null)
            {
                slotList[i].item = item.item;
                slotList[i].itemSprite = item.itemSprite;
                break;
            }
        }
    }
}
