using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameObject pigheads;
    [SerializeField] GameObject crazypigs;
    [SerializeField] GameObject pigbodies;

    bool CareAboutTheOpinionsOfOthers;

    void Awake()
    {
        //Halloween 1987
        CareAboutTheOpinionsOfOthers = true;
    }

    public IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(3));
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (CareAboutTheOpinionsOfOthers)
        {
            setPhase2();
            uihandler.LoseDisplay();
        } else
        {
            uihandler.WinDisplay();
        }
    }

    private void setPhase1()
    {
        pigheads.SetActive(true);
        pigbodies.SetActive(true);
        crazypigs.SetActive(false);
    }

    private void setPhase2()
    {
        pigheads.SetActive(false);
        pigbodies.SetActive(false);
        crazypigs.SetActive(true);
    }

    public void Reset()
    {
        setPhase1();
    }
}
