using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenWages : MonoBehaviour
{
    ThreeSecondsLeft threeSecondsLeft;
    PlayerController playerController;

    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        threeSecondsLeft.WinDisplay();
        playerController.OnDisable();
    }
}
