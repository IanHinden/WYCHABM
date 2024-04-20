﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] UIHandler uiHandler;
    [SerializeField] ScoreHandler scoreHandler;

    [SerializeField] GameObject scoreScreen;

    [SerializeField] ScoreStamp scoreStampPart1;
    [SerializeField] ScoreStamp scoreStampPart2;
    [SerializeField] ScoreStamp scoreStampPart3;
    [SerializeField] ScoreStamp scoreStampFinal;

    [SerializeField] GameObject resetGameButton;

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
        scoreStampPart2.SetGrade(scoreHandler.ReturnPartTwoGrade());
        scoreStampPart2.AnimateStamp();
        yield return new WaitForSeconds(.635f);
        scoreStampPart3.SetGrade(scoreHandler.ReturnPartThreeGrade());
        scoreStampPart3.AnimateStamp();
        yield return new WaitForSeconds(1.27f);
        scoreStampFinal.SetGrade(scoreHandler.ReturnFinalGrade());
        scoreStampFinal.AnimateStamp();
        yield return new WaitForSeconds(2f);
        resetGameButton.SetActive(true);
    }

    public void Reset()
    {
        scoreStampPart1.ResetStamp();
        scoreStampPart2.ResetStamp();
        scoreStampPart3.ResetStamp();
        scoreStampFinal.ResetStamp();
        resetGameButton.SetActive(false);
    }
}
