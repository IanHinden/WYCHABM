using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerPG : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float quarter;
    private float timePassed = 0f;

    private Animator gothGirl;

    private SpriteRenderer bubbleBackground;

    private Animator clubGirl1;

    // Start is called before the first frame update
    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();
        quarter = measureMS / 4;

        gothGirl = FindObjectOfType<GothGirl>().GetComponent<Animator>();

        bubbleBackground = FindObjectOfType<BubbleBackground>().GetComponent<SpriteRenderer>();

        clubGirl1 = FindObjectOfType<ClubGirl1>().GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timedEvents();
    }

    private void timedEvents()
    {
        if (timePassed > measureMS)
        {
            gothGirl.SetTrigger("Doorway");
        }

        if(timePassed > measureMS * 4)
        {
            bubbleBackground.enabled = true;
        }

        if(timePassed > measureMS * 5)
        {
            clubGirl1.SetTrigger("Pose");
        }
    }
}
