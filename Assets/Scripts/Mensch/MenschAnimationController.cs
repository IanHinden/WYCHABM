using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschAnimationController : MonoBehaviour
{
    Animator blackScreenAnimator;
    Animator safetyAnimator;
    Animator statusAnimator;

    public GameObject Phone;
    public GameObject CreepyDriver;
    public GameObject Fist;

    Animator phoneDown;
    Animator punched;
    Animator punch;
    void Awake()
    {
        blackScreenAnimator = Phone.GetComponent<Animator>();
        safetyAnimator = FindObjectOfType<Safety>().GetComponent<Animator>();
        statusAnimator = FindObjectOfType<Status>().GetComponent<Animator>();

        phoneDown = Phone.GetComponent<Animator>();
        punched = Fist.GetComponent<Animator>();
        punch = CreepyDriver.GetComponent<Animator>();

        phoneDown = Phone.GetComponent<Animator>();
        punched = CreepyDriver.GetComponent<Animator>();
        punch = Fist.GetComponent<Animator>();
    }

    public void ScreenFade()
    {
        blackScreenAnimator.SetTrigger("FadeOut");
    }

    //.47, -2.38

    public void SafetyEnter()
    {
        safetyAnimator.SetTrigger("Enter");
    }

    public void SafetyExit()
    {
        safetyAnimator.SetTrigger("Exit");
    }

    public void StatusEnter()
    {
        statusAnimator.SetTrigger("Enter");
    }

    public void StatusExit()
    {
        statusAnimator.SetTrigger("Exit");
    }

    public void BonusAnimations()
    {
        phoneDown.SetTrigger("PhoneDown");
        punched.SetTrigger("Punched");
        punch.SetTrigger("Punch");
    }
}
