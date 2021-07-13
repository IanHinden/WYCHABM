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
        textmesh = GameObject.Find("CountdownImages").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
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
