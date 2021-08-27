using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarViewTiming : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private float measureMS;
    private float timePassed = 0f;

    [SerializeField] private GameObject cellPhone;

    SpriteRenderer manStaring;

    void Awake()
    {
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();
        measureMS = threeSecondsLeft.ReturnSingleMeasure();

        //cellPhone = FindObjectOfType<CellPhone>();
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
            manStaring.enabled = false;
        }
    }
}
