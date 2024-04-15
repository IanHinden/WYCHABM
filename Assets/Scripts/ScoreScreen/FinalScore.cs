using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] UIHandler uiHandler;
    [SerializeField] ScoreHandler scoreHandler;

    [SerializeField] GameObject scoreScreen;

    [SerializeField] ScoreStamp scoreStampPart1;
    [SerializeField] ScoreStamp scoreStampPart2;
    [SerializeField] ScoreStamp scoreStampPart3;
    [SerializeField] ScoreStamp scoreStampFinal;

    [SerializeField] AudioSource gameOverTheme;

    private string standardScore;
    private string bonusScore;

    private void Awake()
    {
        StartCoroutine(ScoreText());
    }

    public IEnumerator ScoreText()
    {
        standardScore = scoreHandler.ReturnScore().ToString();
        bonusScore = scoreHandler.ReturnBonusScore().ToString();

        uiHandler.SetScoreScreenStandardScore("");
        uiHandler.SetScoreScreenBonusScore("");

        yield return new WaitForSeconds(.3f);
        gameOverTheme.Play();
        yield return new WaitForSeconds(1.9f);
        scoreStampPart1.SetGrade(scoreHandler.ReturnPartOneGrade());
        scoreStampPart1.AnimateStamp();
        yield return new WaitForSeconds(.635f);
        scoreStampPart2.SetGrade("D");
        scoreStampPart2.AnimateStamp();
        yield return new WaitForSeconds(.635f);
        scoreStampPart3.SetGrade("D");
        scoreStampPart3.AnimateStamp();
        yield return new WaitForSeconds(1.27f);
        scoreStampFinal.SetGrade("B");
        scoreStampFinal.AnimateStamp();
    }
}
