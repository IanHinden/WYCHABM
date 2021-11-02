using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenWages : MonoBehaviour
{
    public static event Action<int> WagesGet = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WagesGet(1);
        Destroy(gameObject);
    }
}
