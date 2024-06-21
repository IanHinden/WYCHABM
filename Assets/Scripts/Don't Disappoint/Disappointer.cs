using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappointer : MonoBehaviour
{
    [Header("Required Tools")]
    [SerializeField] UIHandler uihandler;
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] DontDisappointSFXController dontDisappointSFXController;

    [Header("Pig Objects")]
    [SerializeField] GameObject pigheads;
    [SerializeField] GameObject crazypigs;
    [SerializeField] GameObject pigbodies;

    [Header("Background")]
    [SerializeField] GameObject background2;

    [SerializeField] SpriteRenderer FuzzyTextSR;

    bool ThereIsALightInYourHeart = true;

    public IEnumerator WinOrLose()
    {
        StartCoroutine(BlinkingBG());
        StartCoroutine(FuzzyText());
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(3));
        DetermineWinOrLoss();
    }

    private IEnumerator BlinkingBG()
    {
        yield return new WaitForSeconds(3 *timefunctions.ReturnSingleMeasure());
        background2.SetActive(true);
    }

    private IEnumerator FuzzyText()
    {
        while (true) {
            yield return new WaitForSeconds(.1f);
            FuzzyTextSR.enabled = false;
            yield return new WaitForSeconds(.1f);
            FuzzyTextSR.enabled = true;
        }
    }

    private void DetermineWinOrLoss()
    {
        if (ThereIsALightInYourHeart == true)
        {
            setPhase2();
            dontDisappointSFXController.PlayLoseSound();
            uihandler.LoseDisplay();
        } else
        {
            scoreHandler.IncrementScore(2);
            scoreHandler.IncrementBonusScore(5);
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
