using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThreeSecondsLeft : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private float BPM = 85f;
    private float measureMS;

    void Awake()
    {
        measureMS = 60 / BPM;
        if (GameObject.Find("CountdownImages") != null)
        {
            textmesh = GameObject.Find("CountdownImages").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }
    }

    public float ReturnBPM()
    {
        return BPM;
    }

    public float ReturnSingleMeasure()
    {
        return measureMS;
    }

    public float ReturnTimeToEnd()
    {
        return measureMS * 4;
    }

    public void StartCountdown()
    {
        StartCoroutine(TriggerCountdownAnimation(BPM));
    }

    IEnumerator TriggerCountdownAnimation(float BPM)
    {
        if (GameObject.Find("CountdownImages") != null)
        {
            textmesh.text = "3";

            yield return new WaitForSeconds(measureMS);
            textmesh.text = "2";

            yield return new WaitForSeconds(measureMS);
            textmesh.text = "1";

            yield return new WaitForSeconds(measureMS);
            textmesh.text = "0";
        }
    }
}
