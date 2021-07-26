using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTimer : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private TextMeshProUGUI sugarDaddiesTM;

    private float measureMS;
    private float timePassed = 0f;

    Pointer pointer;
    Animator pointerAnim;

    private SpriteRenderer laptop;
    private SpriteRenderer charts;
    private SpriteRenderer sugarDaddies;
    private SpriteRenderer pointerSR;
    // Start is called before the first frame update
    void Awake()
    {
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();

        pointer = FindObjectOfType<Pointer>();
        pointerAnim = pointer.GetComponent<Animator>();
        pointerSR = pointer.GetComponent<SpriteRenderer>();

        laptop = FindObjectOfType<Laptop>().GetComponent<SpriteRenderer>();
        charts = FindObjectOfType<Charts>().GetComponent<SpriteRenderer>();

        sugarDaddiesTM = FindObjectOfType<SugarDaddiesText>().GetComponent<TextMeshProUGUI>();
        sugarDaddies = FindObjectOfType<SugarDaddies>().GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timedEvents();
    }

    private void timedEvents()
    {
        if(timePassed > measureMS * 4)
        {
            laptop.enabled = true;
            charts.enabled = true;
            pointerSR.enabled = true;
        }

        if (timePassed > measureMS * 8)
        {
            laptop.enabled = false;
            charts.enabled = false;
            pointerSR.enabled = false;
        }

        if (timePassed > measureMS * 12)
        {
            laptop.enabled = true;
            charts.enabled = true;
            pointerSR.enabled = true;
            pointerAnim.SetTrigger("Pointer");
        }

        if (timePassed > measureMS * 16)
        {
            sugarDaddies.enabled = true;
            sugarDaddiesTM.SetText("Sweet Sugar " +
            "Daddies Site");
        }
    }

    private void Test()
    {
        Debug.Log("Yup!");
    }
}
