using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTimer : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    private float measureMS;

    Pointer pointer;
    Animator pointerAnim;

    private SpriteRenderer laptop;
    private SpriteRenderer charts;
    private SpriteRenderer pointerSR;
 
    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        pointer = FindObjectOfType<Pointer>();
        pointerAnim = pointer.GetComponent<Animator>();
        pointerSR = pointer.GetComponent<SpriteRenderer>();

        laptop = FindObjectOfType<Laptop>().GetComponent<SpriteRenderer>();
        charts = FindObjectOfType<Charts>().GetComponent<SpriteRenderer>();

        StartCoroutine(timedEvents());
    }

    private IEnumerator timedEvents()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));
        laptop.enabled = true;
        charts.enabled = true;
        pointerSR.enabled = true;

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));
        laptop.enabled = false;
        charts.enabled = false;
        pointerSR.enabled = false;

        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));
        laptop.enabled = true;
        charts.enabled = true;
        pointerSR.enabled = true;
        pointerAnim.SetTrigger("Pointer");
    }
}
