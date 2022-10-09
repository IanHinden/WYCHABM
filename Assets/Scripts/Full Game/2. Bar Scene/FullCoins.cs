using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullCoins : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] UIHandler uihandler;
    //Animator starAnim;

    int remainingCoins;
    //bool stolenWagesRecovered = false;

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
        //threeSecondsLeft.DisplayScoreCard();
        //threeSecondsLeft.WinDisplay();
        //threeSecondsLeft.DisplayBonusScoreCard(starAnim);
        Debug.Log("Stolen wages");
        controller.OnDisable();
    }

    private void MinusCoin(int amount)
    {
        remainingCoins--;
        if (remainingCoins == 0 && levelComplete == false)
        {
            levelComplete = true;
            uihandler.WinDisplay();
            //threeSecondsLeft.DisplayScoreCard();
            //threeSecondsLeft.WinDisplay();
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
            //threeSecondsLeft.WinDisplay();
        }
        else
        {
            uihandler.LoseDisplay();
            //playerController.OnDisable();
        }
    }
}
