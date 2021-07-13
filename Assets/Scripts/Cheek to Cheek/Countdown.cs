using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float BPM;
    void Awake()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();
        BPM = threeSecondsLeft.ReturnBPM();
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCountdown()
    {
        StartCoroutine(TriggerCountdownAnimation(BPM));
    }


    IEnumerator TriggerCountdownAnimation(float BPM)
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
    }
}
