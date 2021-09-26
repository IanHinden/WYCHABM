using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float pregnancyScore = 0;
    bool full = false;

    ThreeSecondsLeft threeSecondsLeft;

    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pregnancyScore == 50 && full == false)
        {
            full = true;
            threeSecondsLeft.DisplayScoreCard();
            threeSecondsLeft.WinDisplay();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        pregnancyScore++;
    }
}
