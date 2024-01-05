using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerPG : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameObject gettingReady;

    private float measureMS;
    public float rotationSpeed = 1f;
    public float rotationDuration = 2f;

    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        StartCoroutine(timedEvents());
    }

    private IEnumerator timedEvents()
    {
        yield return new WaitForSeconds(1.5f);
        gettingReady.SetActive(false);
    }

    public void Reset()
    {
        gettingReady.SetActive(true);
    }
}
