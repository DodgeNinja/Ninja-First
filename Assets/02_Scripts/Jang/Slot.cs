using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enum;

public class Slot : MonoBehaviour
{
    public ItemEnum item;
    public Sprite itemSprite;

    private new BoxCollider2D collider2D;
    private Image image;

    private void Awake()
    {
        collider2D = gameObject.GetComponent<BoxCollider2D>();
        image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        image.sprite = itemSprite;
    }

    private void TouchSlot()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

        if (hit.collider == collider2D)
        {
            //플레이어한테 줄 버프함수 넣기
            SlotReset();
        }
    }

    void SlotReset()
    {
        item = ItemEnum.Null;
        itemSprite = null;
    }
}
