using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullCoins : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] UIHandler uihandler;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] TextMeshProUGUI displayscore;
    //Animator starAnim;

    int totalCoins;
    int remainingCoins;

    private bool levelComplete = false;

    void Awake()
    {
        Coin.CoinGet += MinusCoin;
        StolenWages.WagesGet += StolenWagesRecovered;
        //starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(2).GetComponent<Animator>();
        totalCoins = gameObject.transform.childCount;
        remainingCoins = totalCoins;

        StartCoroutine(WinOrLose());
    }

    private void StolenWagesRecovered(int amount)
    {
        levelComplete = true;
        scorehandler.IncrementScore();
        //threeSecondsLeft.DisplayBonusScoreCard(starAnim);
        uihandler.WinDisplay();
        controller.OnDisable();
    }

    private void MinusCoin(int amount)
    {
        remainingCoins--;
        if (remainingCoins == 0 && levelComplete == false)
        {
            levelComplete = true;
            uihandler.WinDisplay();
            scorehandler.IncrementScore();
            controller.OnDisable();
        }
        displayscore.text = totalCoins - remainingCoins + "/" + totalCoins;
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));

        if (levelComplete == false)
        {
            DetermineWinOrLoss();
        }
    }

    private void DetermineWinOrLoss()
    {
        if (!levelComplete)
        {
            if (remainingCoins == 0)
            {
                uihandler.WinDisplay();
                controller.OnDisable();
                scorehandler.IncrementScore();
            }
            else
            {
                uihandler.LoseDisplay();
                controller.OnDisable();
            }
        }
    }
}
