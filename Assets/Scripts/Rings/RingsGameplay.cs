﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsGameplay : MonoBehaviour
{
    Remove remove;
    float clicked = 0;

    Animator ringoneanim;
    Animator ringtwoanim;

    ThreeSecondsLeft threeSecondsLeft;

    void Awake()
    {
        remove = new Remove();
        remove.Tap.Up.performed += x => RemoveRing();

        ringoneanim = FindObjectOfType<Ring>().GetComponent<Animator>();
        ringtwoanim = FindObjectOfType<RingTwo>().GetComponent<Animator>();

        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
    }

    private void OnEnable()
    {
        remove.Enable();
    }

    private void OnDisable()
    {
        remove.Disable();
    }

    private void RemoveRing()
    {
        clicked++;

        if(clicked == 1)
        {
            ringoneanim.SetTrigger("Start");
        }

        if (clicked == 2)
        {
            ringoneanim.SetTrigger("Second");
        }

        if (clicked == 3)
        {
            ringoneanim.SetTrigger("Third");
        }

        if (clicked == 5)
        {
            ringtwoanim.SetTrigger("Start");
        }

        if (clicked == 9)
        {
            ringtwoanim.SetTrigger("Second");
        }

        if (clicked == 14)
        {
            ringtwoanim.SetTrigger("Third");
        }

        if (clicked == 19)
        {
            ringtwoanim.SetTrigger("Fourth");
            threeSecondsLeft.DisplayScoreCard();
        }
    }
}
