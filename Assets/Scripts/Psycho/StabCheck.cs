﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabCheck : MonoBehaviour
{
    //SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;

    Animator starAnim;

    public GameObject oedipalBonus;

    bool stabbed = false;
    bool oedipal = false;

    private void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();

        starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(4).GetComponent<Animator>();
        StartCoroutine(WinOrLose());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "OedipalBonus")
        {
            Vector3 textPos = transform.position;
            textPos.x = transform.position.x - 3;
            Instantiate(oedipalBonus, textPos, Quaternion.identity);
            oedipal = true;
            if(stabbed == false)
            {
                threeSecondsLeft.DisplayBonusScoreCard(starAnim);
            }
        }
        stabbed = true;
        threeSecondsLeft.WinDisplay();
    }

    IEnumerator WinOrLose()
    {
        float deadline = (2 * threeSecondsLeft.ReturnTimeToEnd()) - threeSecondsLeft.ReturnSingleMeasure();

        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (stabbed == false)
        {
            threeSecondsLeft.LoseDisplay();
        }
    }
}
