using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerOD : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float timePassed = 0f;

    private Topless topless;
    private SpriteRenderer flashing;
    private Animator flashingMove;
    // Start is called before the first frame update
    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();

        topless = FindObjectOfType<Topless>();
        flashing = topless.GetComponent<SpriteRenderer>();
        flashingMove = topless.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timedEvents();
    }

    private void timedEvents()
    {
        if (timePassed > measureMS * 2)
        {
            flashing.enabled = true;
        }

        if(timePassed > measureMS * 3)
        {
            flashingMove.SetTrigger("Flash");
        }
    }
}
