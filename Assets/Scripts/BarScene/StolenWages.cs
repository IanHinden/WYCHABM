using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenWages : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        collected = true;
    }

    public bool IsCollected()
    {
        return collected;
    }
}
