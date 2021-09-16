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

    private bool started = false;
    void Awake()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();
        BPM = threeSecondsLeft.ReturnBPM();
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
