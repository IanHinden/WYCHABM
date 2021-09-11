﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsGameplay : MonoBehaviour
{
    Remove remove;
    float clicked = 0;

    Animator ringoneanim;
    Animator ringtwoanim;

    void Awake()
    {
        remove = new Remove();
        remove.Tap.Up.performed += x => RemoveRing();

        ringoneanim = FindObjectOfType<Ring>().GetComponent<Animator>();
        ringtwoanim = FindObjectOfType<RingTwo>().GetComponent<Animator>();
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

        if (clicked == 4)
        {
            ringoneanim.SetTrigger("Second");
        }

        if (clicked == 9)
        {
            ringoneanim.SetTrigger("Third");
        }

        if (clicked == 15)
        {
            ringtwoanim.SetTrigger("Start");
        }

        if (clicked == 21)
        {
            ringtwoanim.SetTrigger("Second");
        }

        if (clicked == 30)
        {
            ringtwoanim.SetTrigger("Third");
        }

        if (clicked == 40)
        {
            ringtwoanim.SetTrigger("Fourth");
        }
    }
}
