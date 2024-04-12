using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] UIHandler uiHandler;
    [SerializeField] ScoreHandler scoreHandler;

    [SerializeField] GameObject scoreScreen;

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

        uiHandler.SetScoreScreenStandardScore(standardScore + "/16");
        uiHandler.SetScoreScreenBonusScore(bonusScore + "/10");

        yield return new WaitForSeconds(.3f);
        gameOverTheme.Play();
    }
}
