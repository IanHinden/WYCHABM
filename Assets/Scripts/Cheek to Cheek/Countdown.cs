﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float BPM;

    private bool started = false;
    void Awake()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();
        BPM = threeSecondsLeft.ReturnBPM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCountdown()
    {
        StartCoroutine(TriggerCountdownAnimation(BPM));
        started = true;
    }


    IEnumerator TriggerCountdownAnimation(float BPM)
    {
        if (started == false)
        {
            float measureCopy = measureMS;

            textmesh.text = "3";
            measureCopy = measureMS;

            while (measureCopy > 0)
            {
                measureCopy -= Time.deltaTime;
                yield return null;
            }
            textmesh.text = "2";
            measureCopy = measureMS;

            while (measureCopy > 0)
            {
                measureCopy -= Time.deltaTime;
                yield return null;
            }
            measureCopy = measureMS;
            textmesh.text = "1";

            while (measureCopy > 0)
            {
                measureCopy -= Time.deltaTime;
                yield return null;
            }

            textmesh.text = "0";
            yield return new WaitForSeconds(1);
            textmesh.text = "";
        }
    }
}
