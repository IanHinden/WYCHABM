using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] Hand hand;
    void Awake()
    {
        StartCoroutine(WinOrLose());
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(5));
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        bool moved = hand.getMoved();
        if (moved)
        {
            uihandler.LoseDisplay();
        }
        else
        {
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
        }
    }
}
