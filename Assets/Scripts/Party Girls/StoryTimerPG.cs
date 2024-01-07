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
    }

    public IEnumerator timedEvents()
    {
        yield return new WaitForSeconds(2f);
        gettingReady.SetActive(false);
    }

    public void Reset()
    {
        gettingReady.SetActive(true);
    }
}
