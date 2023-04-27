using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enum;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public ItemEnum item;
    public Sprite itemSprite;
    public float boostSpeed;
    public float boostTime;
    public int plusWillPower;

    private Image image;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        image.sprite = itemSprite;
    }

    public void TouchSlot()
    {
        Debug.Log("slotNull");

        switch (item)
        {
            case ItemEnum.Cola:
                StatManager.instance.PlayerBoost(boostSpeed, boostTime);
                break;
            case ItemEnum.Juice:
                StatManager.instance.willPower += plusWillPower;
                break;
        }

        SlotReset();
    }

    void SlotReset()
    {
        item = ItemEnum.Null;
        itemSprite = null;
    }
}
