using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    [Header("Required Tools")]
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] DontDisappointSFXController dontDisappointSFXController;

    [Header("Pig Objects")]
    [SerializeField] GameObject pigheads;
    [SerializeField] GameObject crazypigs;
    [SerializeField] GameObject pigbodies;

    [Header("Background")]
    [SerializeField] GameObject background2;

    bool CareAboutTheOpinionsOfOthers;

    void Awake()
    {
        //Halloween 1987
        CareAboutTheOpinionsOfOthers = true;
    }

    public IEnumerator WinOrLose()
    {
        StartCoroutine(BlinkingBG());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(3));
        DetermineWinOrLoss();
    }

    private IEnumerator BlinkingBG()
    {
        yield return new WaitForSeconds(3 *timefunctions.ReturnSingleMeasure());
        background2.SetActive(true);
        /*yield return new WaitForSeconds(timefunctions.ReturnSingleMeasure());
        background2.SetActive(true);
        yield return new WaitForSeconds(timefunctions.ReturnSingleMeasure());
        background2.SetActive(false);
        yield return new WaitForSeconds(timefunctions.ReturnSingleMeasure());
        background2.SetActive(true);*/
    }

    private void DetermineWinOrLoss()
    {
        if (CareAboutTheOpinionsOfOthers)
        {
            setPhase2();
            dontDisappointSFXController.PlayLoseSound();
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
        background2.SetActive(false);
    }
}
