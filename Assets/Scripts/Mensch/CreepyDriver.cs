using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyDriver : MonoBehaviour
{
    public static event Action BonusWin = delegate { };

    private void OnTriggerEnter2D()
    {
        BonusWin();
    }
}
