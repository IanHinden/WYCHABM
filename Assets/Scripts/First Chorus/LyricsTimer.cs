using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyricsTimer : MonoBehaviour
{
    float interval = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Time:");
        Debug.Log(interval);
        interval = 0;
    }

    private void Update()
    {
        interval += Time.deltaTime;
    }
}
