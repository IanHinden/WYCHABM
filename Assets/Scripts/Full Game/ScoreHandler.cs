using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;

    private int score = 0;
    private int bonusScore = 0;

    private int tinyGameValue = 1000;
    private int totalPointsIncGoodValue = 1000;
    private int totalPointsIncPefectValue = 1500;
    private int totalPointsPartOne;
    private int totalPointsPartTwo;
    private int totalPointsPartThree;

    private int maxScorePartOne;
    private int maxScorePartTwo;
    private int maxScorePartThree;

    private void Awake()
    {
        maxScorePartOne = (8 * totalPointsIncPefectValue) + (3 * tinyGameValue);
        maxScorePartTwo = (15 * totalPointsIncPefectValue) + (6 * tinyGameValue);
        maxScorePartThree = (27 * totalPointsIncPefectValue) + (6 * tinyGameValue);
    }

    private bool[] bonusesDiscovered = new bool[10];
    public void IncrementScore(int part = 0)
    {
        score++;
        StartCoroutine(uihandler.DisplayScoreCard(score));

        if(part == 1)
        {
            totalPointsPartOne += tinyGameValue;
        } else if (part == 2)
        {
            totalPointsPartTwo += tinyGameValue;
        } else if (part == 3)
        {
            totalPointsPartThree += tinyGameValue;
        }
    }

    public void DoubleIncrementScore(int part = 0)
    {
        score = score + 2;
        StartCoroutine(uihandler.DisplayScoreCardTwo(score));

        if(part == 2)
        {
            totalPointsPartTwo += (2 * tinyGameValue);
        }
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
    }

    public void IncrementTotalPointsPartTwo(bool good)
    {
        if (good)
        {
            totalPointsPartTwo += totalPointsIncGoodValue;
        }
        else
        {
            totalPointsPartTwo += totalPointsIncPefectValue;
        }
    }

    public void IncrementTotalPointsPartThree(bool good)
    {
        if (good)
        {
            totalPointsPartThree += totalPointsIncGoodValue;
        }
        else
        {
            totalPointsPartThree += totalPointsIncPefectValue;
        }
    }

    public void ResetScore()
    {
        score = 0;
        bonusScore = 0;
        totalPointsPartOne = 0;
        totalPointsPartTwo = 0;
        totalPointsPartThree = 0;
    }

    public int ReturnScore()
    {
        return score;
    }

    public int ReturnBonusScore()
    {
        return bonusScore;
    }

    public int ReturnTotalPointsPartOne()
    {
        return totalPointsPartOne;
    }

    public int ReturnTotalPointsPartTwo()
    {
        return totalPointsPartTwo;
    }

    public int ReturnTotalPointsPartThree()
    {
        return totalPointsPartThree;
    }

    public string ReturnPartOneGrade()
    {
        return GradeGenerator(totalPointsPartOne, maxScorePartOne);
    }

    public string ReturnPartTwoGrade()
    {
        return GradeGenerator(totalPointsPartTwo, maxScorePartTwo);
    }

    public string ReturnPartThreeGrade()
    {
        return GradeGenerator(totalPointsPartThree, maxScorePartThree);
    }

    public string ReturnFinalGrade()
    {
        int totalScore = totalPointsPartOne + totalPointsPartTwo + totalPointsPartThree;
        int totalMaxScore = maxScorePartOne + maxScorePartTwo + maxScorePartThree;

        return GradeGenerator(totalScore, totalMaxScore);
    }

    private string GradeGenerator(int score, int maxScore)
    {
        float percentageOfTotal = (float)score / maxScore;
        float baseScore = maxScore * percentageOfTotal;
        float sections = maxScore / 6;

        string grade = "F";

        if(baseScore >= sections)
        {
            grade = "F";
        }

        if(baseScore >= (2 * sections))
        {
            grade = "D";
        }

        if (baseScore >= (3 * sections))
        {
            grade = "C";
        }

        if (baseScore >= (4 * sections))
        {
            grade = "B";
        }

        if (baseScore >= (5 * sections))
        {
            grade = "A";
        }

        if (baseScore >= (5.5 * sections))
        {
            grade = "S";
        }

        return grade;
    }
}
