using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User 
{
    public string _name;
    public int _gold;
    public int _level;

    public User(string name, int gold, int level = 1)
    {
        this._name = name;
        this._gold = gold;
        this._level = level;
    }
    
}
