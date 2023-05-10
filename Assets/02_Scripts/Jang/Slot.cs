using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enum;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [Header("infomation")]
    public ItemEnum item;
    public Sprite itemSprite;
    public float boostSpeed;
    public float boostTime;
    public int plusWillPower;

    private Image image;
    private AudioSource audioSource;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
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
                audioSource.Play();
                break;
            case ItemEnum.Juice:
                StatManager.instance.willPower += plusWillPower;
                audioSource.Play();
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
