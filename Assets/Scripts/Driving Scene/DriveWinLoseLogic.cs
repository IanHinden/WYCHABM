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
            //Bonus score logic
            Debug.Log("BONUS WIN");
        } else if (standardWin == true)
        {
            uiHandler.WinDisplay();
        } else
        {
            uiHandler.LoseDisplay();
        }

        /*if (roadRacer.GetScore() > 10)
        {
            Debug.Log("Win");
        } else
        {
            Debug.Log("Lose");
        }*/
    }
}
