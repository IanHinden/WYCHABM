using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] GameObject numberPeople;

    [SerializeField] SteamAchievementHandler steamAchievementHandler;

    private int score = 0;
    private int bonusScore = 0;

    private int tinyGameValue = 1000;
    private int totalPointsIncGoodValue = 300;
    private int totalPointsIncPefectValue = 400;
    private int totalPointsPartOne;
    private int totalPointsPartTwo;
    private int totalPointsPartThree;

    private int maxScorePartOne;
    private int maxScorePartTwo;
    private int maxScorePartThree;

    private float bonusScorePartTwoMin;
    private float bonusScorePartThreeMin;

    private bool bonusScorePartTwoActivated = false;
    private bool bonusScorePartThreeActivated = false;

    private BoolArrayWrapper bonusesDiscovered;

    private void Awake()
    {
        maxScorePartOne = (8 * totalPointsIncPefectValue) + (3 * tinyGameValue);
        //Removing one tiny game value for Don't scene
        maxScorePartTwo = (15 * totalPointsIncPefectValue) + (5 * tinyGameValue);
        maxScorePartThree = (27 * totalPointsIncPefectValue) + (6 * tinyGameValue);

        bonusScorePartTwoMin = maxScorePartTwo * .8f;
        bonusScorePartThreeMin = maxScorePartThree * .8f;

        LoadSave();
    }
    private void LoadSave()
    {
        bonusesDiscovered = SaveSystem.Load(10);

        for(int i = 0; i < bonusesDiscovered.unlockedBonuses.Length; i++)
        {
            if(bonusesDiscovered.unlockedBonuses[i] == true)
            {
                bonusScore++;

                Transform child = numberPeople.transform.GetChild(i);
                Image childImage = child.GetComponent<Image>();

                Animator childAnim = numberPeople.transform.GetChild(i).GetComponent<Animator>();
                childAnim.enabled = false;

                if(childImage != null)
                {
                    childImage.color = Color.black;
                }
            }
        }
    }

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
        if (bonusesDiscovered.unlockedBonuses[numberPerson - 1] == false)
        {
            bonusScore++;

           if(bonusScore == 1)
            {
                steamAchievementHandler.UnlockAchievement(0);
            }

           if(bonusScore == 9)
            {
                steamAchievementHandler.UnlockAchievement(6);
            }

            bonusesDiscovered.unlockedBonuses[numberPerson - 1] = true;

            if(bonusesDiscovered.unlockedBonuses[0] == true && bonusesDiscovered.unlockedBonuses[1] == true && bonusesDiscovered.unlockedBonuses[2] == true && bonusesDiscovered.unlockedBonuses[3] == true)
            {
                steamAchievementHandler.UnlockAchievement(2);
            }

            StartCoroutine(uihandler.DisplayBonusScoreCard(numberPerson));
            SaveSystem.Save(bonusesDiscovered);
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

        if(totalPointsPartTwo > bonusScorePartTwoMin && bonusScorePartTwoActivated == false)
        {
            bonusScorePartTwoActivated = true;
            IncrementBonusScore(7);
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

        if(totalPointsPartThree > bonusScorePartThreeMin && bonusScorePartThreeActivated == false)
        {
            bonusScorePartThreeActivated = true;
            IncrementBonusScore(10);
        }
    }

    public void ResetScore()
    {
        score = 0;
        bonusScore = 0;
        totalPointsPartOne = 0;
        totalPointsPartTwo = 0;
        totalPointsPartThree = 0;

        bonusScorePartTwoActivated = false;
        bonusScorePartThreeActivated = false;
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

    public BoolArrayWrapper ReturnBonusesDiscovered()
    {
        return bonusesDiscovered;
    }
}
