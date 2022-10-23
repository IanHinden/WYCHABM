using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerOD : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    private float measureMS;

    [SerializeField] private Topless topless;
    private SpriteRenderer flashing;
    private Animator flashingMove;

    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        flashing = topless.GetComponent<SpriteRenderer>();
        flashingMove = topless.GetComponent<Animator>();
        StartCoroutine(SceneTiming());
    }

    private IEnumerator SceneTiming()
    {
        yield return new WaitForSeconds(measureMS * 8f);
        flashing.enabled = true;
        yield return new WaitForSeconds(measureMS * 1);
        flashingMove.SetTrigger("Flash");
    }
}
