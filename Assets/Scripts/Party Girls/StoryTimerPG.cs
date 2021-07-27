using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerPG : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float quarter;
    private float timePassed = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();
        quarter = measureMS / 4;
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
        }
    }
}
