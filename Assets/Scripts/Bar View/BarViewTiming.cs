using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarViewTiming : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float timePassed = 0f;

    CellPhone cellPhone;

    void Awake()
    {
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();

        cellPhone = FindObjectOfType<CellPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timedEvents();
    }

    private void timedEvents()
    {
        if (timePassed > measureMS * 4)
        {
            Debug.Log("A measure");
        }
    }
}
