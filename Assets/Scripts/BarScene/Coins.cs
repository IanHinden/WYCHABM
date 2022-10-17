using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    ThreeSecondsLeft threeSecondsLeft;
    [SerializeField] PlayerController playerController;
    Animator starAnim;

    int remainingCoins;

    private bool levelComplete = false;

    void Awake()
    {
        Coin.CoinGet += MinusCoin;
        StolenWages.WagesGet += StolenWagesRecovered;
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(2).GetComponent<Animator>();
        remainingCoins = gameObject.transform.childCount;

        StartCoroutine(WinOrLose());
    }

    private void StolenWagesRecovered(int amount)
    {
        levelComplete = true;
        threeSecondsLeft.DisplayScoreCard();
        threeSecondsLeft.WinDisplay();
        threeSecondsLeft.DisplayBonusScoreCard(starAnim);
        playerController.OnDisable();
    }

    private void MinusCoin(int amount)
    {
        remainingCoins--;
        if (remainingCoins == 0 && levelComplete == false)
        {
            levelComplete = true;
            threeSecondsLeft.DisplayScoreCard();
            threeSecondsLeft.WinDisplay();
            playerController.OnDisable();
        }
    }

    IEnumerator WinOrLose()
    {
        float timeToEnd = (2 * threeSecondsLeft.ReturnTimeToEnd()) - threeSecondsLeft.ReturnSingleMeasure();

        yield return new WaitForSeconds(timeToEnd);

        if (levelComplete == false)
        {
            DetermineWinOrLoss();
        }
    }

    private void DetermineWinOrLoss()
    {
        if(remainingCoins == 0)
        {
            threeSecondsLeft.DisplayScoreCard();
            threeSecondsLeft.WinDisplay();
        } else
        {
            threeSecondsLeft.LoseDisplay();
            playerController.OnDisable();
        }
    }
}
