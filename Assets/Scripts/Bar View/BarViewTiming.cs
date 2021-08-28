using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarViewTiming : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float timePassed = 0f;

    [SerializeField] private GameObject barScene;
    [SerializeField] private GameObject cellPhone;
    Animator cellPhoneAnim;
    Animator barSceneAnim;

    SpriteRenderer manStaring;

    void Awake()
    {
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();

        cellPhoneAnim = cellPhone.GetComponent<Animator>();
        barSceneAnim = barScene.transform.GetChild(2).GetComponent<Animator>();

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
            cellPhone.SetActive(true);
            barScene.SetActive(true);
            manStaring.enabled = false;
        }

        if(timePassed > measureMS * 8)
        {
            cellPhoneAnim.SetTrigger("Lower");
        }

        if (timePassed > measureMS * 10)
        {
            barSceneAnim.SetTrigger("Blink");
        }
    }
}
