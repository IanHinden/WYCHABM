using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;

    // Start is called before the first frame update
    void Awake()
    {
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
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
            successOrFail.WinDisplay();
        }
    }

    IEnumerator WinOrLose()
    {
        float timeToEnd = (2 * threeSecondsLeft.ReturnTimeToEnd()) - threeSecondsLeft.ReturnSingleMeasure();

        while (timeToEnd > 0)
        {
            timeToEnd -= Time.deltaTime;
            yield return null;
        }

        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        int remainingCoins = GetRemainingCoins();
        if(remainingCoins == 0)
        {
            successOrFail.WinDisplay();
        } else
        {
            successOrFail.LoseDisplay();
        }
    }
}
