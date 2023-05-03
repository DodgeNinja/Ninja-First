using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private Slot[] slots;
    [SerializeField] private ItemData itemData;
    [SerializeField] private GameObject inventory;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (inventory.activeSelf)
            {
                case true:
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    inventory.SetActive(false);
                    break;
                case false:
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    inventory.SetActive(true);
                    break;
            }
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
                slots[i].boostSpeed = item.boostSpeed;
                slots[i].boostTime = item.boostTime;
                slots[i].plusWillPower = item.plusWillPower;
                break;
            }
        }
    }
}
