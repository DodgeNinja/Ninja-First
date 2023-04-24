using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 defaultPos;
    private Vector2 orgPos;

    void Awake()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        orgPos = this.transform.position;
        defaultPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Collider2D[] otherSlot = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0, LayerMask.GetMask("Slot"));
        Debug.Log(otherSlot.Length);
        if (otherSlot.Length >= 2)
        {
            Debug.Log(otherSlot.Length);
        }
        this.transform.position = defaultPos;
    }
}