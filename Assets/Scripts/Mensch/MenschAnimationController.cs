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
    public GameObject Finger;

    Animator menschLogoAnim;
    Animator phoneDown;
    Animator fistPunchedAnim;
    Animator driverPunchedAnim;
    Animator fingerAnim;
    void Awake()
    {
        menschLogoAnim = menschLogo.GetComponent<Animator>();
        phoneDown = Phone.GetComponent<Animator>();
        fistPunchedAnim = Fist.GetComponent<Animator>();
        driverPunchedAnim = CreepyDriver.GetComponent<Animator>();
        fingerAnim = Finger.GetComponent<Animator>();
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

    public void PhoneDown()
    {
        phoneDown.SetTrigger("PhoneDown");
    }

    public void Punch()
    {
        fistPunchedAnim.SetTrigger("Punched");
    }

    public void DriverPunched()
    {
        driverPunchedAnim.SetTrigger("Punched");
    }

    public void FingerDown()
    {
        fingerAnim.enabled = true;
        fingerAnim.SetTrigger("FingerDown");
    }

    public void BonusAnimations()
    {
        PhoneDown();
        FingerDown();
        Punch();
        DriverPunched();
    }

    public void Reset()
    {
        fingerAnim.enabled = true;
        phoneDown.ResetTrigger("PhoneDown");
        fistPunchedAnim.ResetTrigger("Punched");
        driverPunchedAnim.ResetTrigger("Punched");
        fingerAnim.ResetTrigger("FingerDown");

        //Reset positions of everything
    }
}
