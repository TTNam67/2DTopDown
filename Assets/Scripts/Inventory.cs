using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<Item> _itemsList;

    public Inventory()
    {
        _itemsList = new List<Item>();
        Debug.Log("Inventory constructor");
    }
}
