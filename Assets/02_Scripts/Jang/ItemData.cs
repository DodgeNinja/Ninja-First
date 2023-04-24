using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enum;

[CreateAssetMenu(menuName = "SO/ITEM")]
public class ItemData : ScriptableObject
{
    public ItemEnum item;
    public Sprite itemSprite;
}
