using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] UIHandler uiHandler;
    [SerializeField] ScoreHandler scoreHandler;

    private string standardScore;
    private string bonusScore;

    public IEnumerator ScoreText()
    {
        standardScore = scoreHandler.ReturnScore().ToString();
        bonusScore = scoreHandler.ReturnBonusScore().ToString();

        uiHandler.SetScoreScreenStandardScore(standardScore + "/16");
        uiHandler.SetScoreScreenBonusScore(bonusScore + "/10");

        yield return null;
    }
}
