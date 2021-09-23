using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float score = 0;

    ThreeSecondsLeft threeSecondsLeft;

    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score == 50)
        {
            threeSecondsLeft.DisplayScoreCard();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        Debug.Log(score);
    }
}
