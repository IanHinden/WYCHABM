﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] UIHandler uihandler;
    private TextMeshProUGUI textmesh;

    private float measureMS;
    private float BPM;

    private bool started = false;
    void Awake()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        measureMS = timefunctions.ReturnSingleMeasure();
        BPM = timefunctions.ReturnBPM();
    }

    public void StartCountdown()
    {
        //StartCoroutine(TriggerCountdownAnimation(BPM));
        uihandler.showSlider();
        uihandler.Countdown(3);
        started = true;
    }

    IEnumerator TriggerCountdownAnimation(float BPM)
    {
        if (started == false)
        {
            textmesh.text = "3";

            yield return new WaitForSeconds(measureMS);
            textmesh.text = "2";

            yield return new WaitForSeconds(measureMS);
            textmesh.text = "1";

            yield return new WaitForSeconds(measureMS);

            textmesh.text = "0";
            yield return new WaitForSeconds(.5f);
            textmesh.text = "";
        }
    }
}
