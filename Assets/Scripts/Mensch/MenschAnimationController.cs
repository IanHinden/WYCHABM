using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschAnimationController : MonoBehaviour
{
    [SerializeField] GameObject menschLogo;
    [SerializeField] GameObject interactiveScreen;
    public GameObject Phone;
    public GameObject CreepyDriver;
    public GameObject Fist;

    Animator menschLogoAnim;
    Animator phoneDown;
    Animator fistPunchedAnim;
    Animator punch;
    void Awake()
    {
        menschLogoAnim = menschLogo.GetComponent<Animator>();
        phoneDown = Phone.GetComponent<Animator>();
        fistPunchedAnim = Fist.GetComponent<Animator>();
        punch = CreepyDriver.GetComponent<Animator>();

        phoneDown = Phone.GetComponent<Animator>();
        //punched = CreepyDriver.GetComponent<Animator>();
        punch = Fist.GetComponent<Animator>();
    }

    public void ScreenFade()
    {
        menschLogoAnim.SetTrigger("Fade");
    }

    public void enableScreen()
    {
        interactiveScreen.SetActive(true);
    }

    //.47, -2.38

    public void BonusAnimations()
    {
        PhoneDown();
        Punch();
        //punch.SetTrigger("Punch");
    }

    public void PhoneDown()
    {
        phoneDown.SetTrigger("PhoneDown");
    }

    public void Punch()
    {
        fistPunchedAnim.SetTrigger("Punched");
    }

    public void Reset()
    {
        phoneDown.ResetTrigger("PhoneDown");
    }
}
