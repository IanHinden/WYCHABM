using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    ThreeSecondsLeft threeSecondsLeft;
    PlayerController playerController;
    StolenWages stolenWages;
    Animator starAnim;

    int remainingCoins;
    bool stolenWagesRecovered = false;

    private bool levelComplete = false;

    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        playerController = FindObjectOfType<PlayerController>();
        stolenWages = FindObjectOfType<StolenWages>();
        starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(2).GetComponent<Animator>();

        StartCoroutine(WinOrLose());
    }

    public int GetRemainingCoins()
    {
        int remainingCoins = gameObject.transform.childCount;
        return remainingCoins;
    }

    //TODO: Change this from Update pattern to Event pattern
    void Update()
    {
        remainingCoins = GetRemainingCoins();
        stolenWagesRecovered = stolenWages.IsCollected();

        if(remainingCoins == 0)
        {
            levelComplete = true;
            playerController.OnDisable();
            threeSecondsLeft.WinDisplay();
        }

        if(stolenWagesRecovered == true)
        {
            levelComplete = true;
            threeSecondsLeft.WinDisplay();
            threeSecondsLeft.DisplayBonusScoreCard(starAnim);
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
        int remainingCoins = GetRemainingCoins();
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
