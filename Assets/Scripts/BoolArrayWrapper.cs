using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolArrayWrapper
{
    public bool[] unlockedBonuses;

    public BoolArrayWrapper(int size)
    {
        unlockedBonuses = new bool[size];
    }
}