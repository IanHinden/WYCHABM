﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action<int> CoinGet = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoinGet(1);
        Destroy(gameObject);
    }
}
