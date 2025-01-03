﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTimer : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameObject computerScreen;
    [SerializeField] GameObject pointer;

    [SerializeField] GameObject greenLaptopScreen;
    [SerializeField] GameObject purpleLaptopScreen;

    Animator pointerAnim;

    private SpriteRenderer pointerSR;
 
    void Awake()
    {
        pointerAnim = pointer.GetComponent<Animator>();
        pointerSR = pointer.GetComponent<SpriteRenderer>();
    }

    public IEnumerator timedEvents()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));
        computerScreen.SetActive(true);
        pointerSR.enabled = true;
        pointerAnim.SetTrigger("Pointer");
        yield return new WaitForSeconds(1.6f);
        greenLaptopScreen.SetActive(false);
        purpleLaptopScreen.SetActive(true);
    }

    public void Reset()
    {
        computerScreen.SetActive(false);
        greenLaptopScreen.SetActive(true);
        purpleLaptopScreen.SetActive(false);
        pointer.transform.position = new Vector3(-2.24f, -1.63f, 0);
        if (pointerSR != null)
        {
            pointerSR.enabled = false;
        }
    }
}
