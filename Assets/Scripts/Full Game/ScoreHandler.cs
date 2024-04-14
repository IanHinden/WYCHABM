using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;

    private int score = 0;
    private int bonusScore = 0;

    private int totalPointsIncGoodValue = 1000;
    private int totalPointsIncPefectValue = 1500;
    private int totalPointsPartOne;

    private bool[] bonusesDiscovered = new bool[10];
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

    public void IncrementBonusScore(int numberPerson)
    {
        if(bonusesDiscovered[numberPerson - 1] == false)
        {
            bonusScore++;
            bonusesDiscovered[numberPerson - 1] = true;
            StartCoroutine(uihandler.DisplayBonusScoreCard(numberPerson));
        } else
        {
            StartCoroutine(uihandler.DisplayBonusScoreCard(numberPerson));
        }
        Debug.Log("Bonus score is: " + bonusScore.ToString());
    }

    public void IncrementTotalPointsPartOne(bool good)
    {
        if (good)
        {
            totalPointsPartOne += totalPointsIncGoodValue;
        } else
        {
            totalPointsPartOne += totalPointsIncPefectValue;
        }
        Debug.Log(totalPointsPartOne);
    }

    public void ResetScore()
    {
        score = 0;
        bonusScore = 0;
        totalPointsPartOne = 0;
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
