using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StolenWages : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayscore;
    public static event Action<int> WagesGet = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        displayscore.text = "2000/6";
        WagesGet(1);
        Destroy(gameObject);
    }
}
