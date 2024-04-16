using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveWinLoseLogic : MonoBehaviour
{
    [SerializeField] RoadRacer roadRacer;
    [SerializeField] UIHandler uiHandler;
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] TimeFunctions timefunctions;

    private bool standardWin = false;
    private float bonusScore = 0;

    public IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(11));

        standardWin = roadRacer.GetStandardPass();
        bonusScore = roadRacer.GetScore();

        if(bonusScore > 10)
        {
            uiHandler.WinDisplay();
            scoreHandler.IncrementScore(2);
            scoreHandler.IncrementBonusScore(6);
        } else if (standardWin == true)
        {
            uiHandler.WinDisplay();
            scoreHandler.IncrementScore(2);
        } else
        {
            uiHandler.LoseDisplay();
        }
    }
}
