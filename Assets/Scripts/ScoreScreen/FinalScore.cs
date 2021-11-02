using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    private TextMeshPro textmesh;
    ThreeSecondsLeft threeSecondsLeft;

    void Awake()
    {
        textmesh = this.gameObject.GetComponent<TextMeshPro>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        ScoreText();
    }

    public void ScoreText()
    {
        textmesh.text = "Final Score: " + threeSecondsLeft.ReturnScore() + "/10" + '\n' + "Bonus Score: " + threeSecondsLeft.ReturnBonusScore() + "/10";
    }
}
