using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;

    bool CareAboutTheOpinionsOfOthers;

    void Awake()
    {
        StartCoroutine(WinOrLose());

        //Halloween 1987
        CareAboutTheOpinionsOfOthers = true;
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(3));
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (CareAboutTheOpinionsOfOthers)
        {
            uihandler.LoseDisplay();
        } else
        {
            uihandler.WinDisplay();
        }
    }
}
