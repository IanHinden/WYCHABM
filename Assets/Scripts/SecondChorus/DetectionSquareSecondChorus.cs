﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DetectionSquareSecondChorus : MonoBehaviour
{
    public static event Action GoodPoint = delegate { };
    public static event Action PerfectPoint = delegate { };

    [SerializeField] RhythmRatingDisplay rhythmRatingDisplay;
    [SerializeField] FadingArrow fadingArrow;

    //public static float score = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        float distance = Vector3.Distance(transform.position, col.gameObject.transform.position);
        if (distance <= 6)
        {
            SpawnPerfect();
            //score = score + 2;
        }
        else if (distance > 6 && distance < 10)
        {
            //score = score + 1;
            SpawnGood();
        }
        else
        {
            SpawnMiss();
        }

        Image arrowImage = col.gameObject.GetComponent<Image>();
        BoxCollider2D arrowBC = col.gameObject.GetComponent<BoxCollider2D>();
        arrowImage.enabled = false;
        arrowBC.enabled = false;

    }

    private void SpawnPerfect()
    {
        SpawnFadingArrow();
        rhythmRatingDisplay.SetPerfect();
        PerfectPoint();
    }

    private void SpawnGood()
    {
        SpawnFadingArrow();
        rhythmRatingDisplay.SetGood();
        GoodPoint();
    }

    private void SpawnMiss()
    {
        SpawnFadingArrow();
        rhythmRatingDisplay.SetMiss();
    }

    /*public float getScore()
    {
        return score;
    }*/

    private void SpawnFadingArrow()
    {
        FadingArrow instantiatedArrow = Instantiate(fadingArrow, transform.position, transform.rotation);
        Quaternion zRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z);
        instantiatedArrow.transform.rotation = zRotation;
        instantiatedArrow.transform.SetParent(transform);

    }

    /*public void resetScore()
    {
        score = 0;
    }*/
}
