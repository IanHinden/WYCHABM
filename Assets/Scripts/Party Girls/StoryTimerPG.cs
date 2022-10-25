using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerPG : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    private float measureMS;

    private Animator gothGirl;

    private SpriteRenderer bubbleBackground;

    private Animator clubGirl1;

    // Start is called before the first frame update
    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        gothGirl = FindObjectOfType<GothGirl>().GetComponent<Animator>();

        bubbleBackground = FindObjectOfType<BubbleBackground>().GetComponent<SpriteRenderer>();

        clubGirl1 = FindObjectOfType<ClubGirl1>().GetComponent<Animator>();

        StartCoroutine(timedEvents());
    }

    private IEnumerator timedEvents()
    {
        yield return new WaitForSeconds(measureMS);
        gothGirl.SetTrigger("Doorway");

        yield return new WaitForSeconds(3 * measureMS);
        bubbleBackground.enabled = true;

        yield return new WaitForSeconds(measureMS);
        clubGirl1.SetTrigger("Pose");
    }
}
