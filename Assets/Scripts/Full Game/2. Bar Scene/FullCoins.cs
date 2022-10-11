using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullCoins : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] UIHandler uihandler;
    [SerializeField] ScoreHandler scorehandler;
    //Animator starAnim;

    int remainingCoins;

    private bool levelComplete = false;

    void Awake()
    {
        Coin.CoinGet += MinusCoin;
        StolenWages.WagesGet += StolenWagesRecovered;
        //starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(2).GetComponent<Animator>();
        remainingCoins = gameObject.transform.childCount;

        StartCoroutine(WinOrLose());
    }

    private void StolenWagesRecovered(int amount)
    {
        levelComplete = true;
        scorehandler.DisplayScoreCard();
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
            scorehandler.DisplayScoreCard();
            controller.OnDisable();
        }
    }

    IEnumerator WinOrLose()
    {
        //float timeToEnd = (2 * threeSecondsLeft.ReturnTimeToEnd()) - threeSecondsLeft.ReturnSingleMeasure();

        //yield return new WaitForSeconds(timeToEnd);
        yield return new WaitForSeconds(5);

        if (levelComplete == false)
        {
            DetermineWinOrLoss();
        }
    }

    private void DetermineWinOrLoss()
    {
        if (remainingCoins == 0)
        {
            uihandler.WinDisplay();
            scorehandler.DisplayScoreCard();
        }
        else
        {
            uihandler.LoseDisplay();
            //playerController.OnDisable();
        }
    }
}
