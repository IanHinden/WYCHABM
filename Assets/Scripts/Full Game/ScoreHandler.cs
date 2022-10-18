using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;

    private int score = 0;
    private int bonusScore = 0;
    public void IncrementScore()
    {
        score++;
        uihandler.DisplayScoreCard(score);
    }
}
