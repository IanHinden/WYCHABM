using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarViewTiming : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float timePassed = 0f;

    [SerializeField] private GameObject normalSit;
    [SerializeField] private GameObject cellPhone;
    Animator cellPhoneAnim;

    SpriteRenderer manStaring;

    void Awake()
    {
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();

        cellPhoneAnim = cellPhone.GetComponent<Animator>();

        manStaring = FindObjectOfType<ManStaring>().GetComponent<SpriteRenderer>();
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
            manStaring.enabled = false;
            cellPhone.SetActive(true);
            normalSit.SetActive(true);
        }

        if(timePassed > measureMS * 8)
        {
            cellPhoneAnim.SetTrigger("Lower");
        }
    }
}
