using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolenWages : MonoBehaviour
{
    ThreeSecondsLeft threeSecondsLeft;
    PlayerController playerController;
    Animator starAnim;

    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        playerController = FindObjectOfType<PlayerController>();
        starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(2).GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        threeSecondsLeft.WinDisplay();
        threeSecondsLeft.DisplayBonusScoreCard(starAnim);
        playerController.OnDisable();
    }
}
