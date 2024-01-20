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
        StartCoroutine(uihandler.DisplayScoreCard(score));
    }

    public void DoubleIncrementScore()
    {
        score = score + 2;
        StartCoroutine(uihandler.DisplayScoreCardTwo(score));
    }

    public void IncrementBonusScore()
    {
        bonusScore++;
        Debug.Log("Bonus score is: " + bonusScore.ToString());
        //Put code here to display bonus score card
    }

    public void ResetScore()
    {
        score = 0;
        bonusScore = 0;
    }

    public int ReturnScore()
    {
        return score;
    }

    public int ReturnBonusScore()
    {
        return bonusScore;
    }
}
