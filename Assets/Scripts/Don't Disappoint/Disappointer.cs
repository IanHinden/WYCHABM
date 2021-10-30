using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    ThreeSecondsLeft threeSecondsLeft;

    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        StartCoroutine(WinOrLose());
    }

    IEnumerator WinOrLose()
    {
        float deadline = threeSecondsLeft.ReturnTimeToEnd() - threeSecondsLeft.ReturnSingleMeasure();
        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        threeSecondsLeft.LoseDisplay();
    }
}
