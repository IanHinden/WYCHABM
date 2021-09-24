using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    ThreeSecondsLeft threeSecondsLeft;

    // Start is called before the first frame update
    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();

        StartCoroutine(WinOrLose());
    }

    public int GetRemainingCoins()
    {
        int remainingCoins = gameObject.transform.childCount;
        return remainingCoins;
    }

    // Update is called once per frame
    void Update()
    {
        int remainingCoins = GetRemainingCoins();
        if(remainingCoins == 0)
        {
            threeSecondsLeft.WinDisplay();
        }
    }

    IEnumerator WinOrLose()
    {
        float timeToEnd = (2 * threeSecondsLeft.ReturnTimeToEnd()) - threeSecondsLeft.ReturnSingleMeasure();

        yield return new WaitForSeconds(timeToEnd);

        DetermineWinOrLoss();
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
        }
    }
}
