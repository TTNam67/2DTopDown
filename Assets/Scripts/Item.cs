using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword, 
        HealthPotion,
        SpeedPotion,
        Coin
    }

    public ItemType _itemType;
    public int _amount;
}
