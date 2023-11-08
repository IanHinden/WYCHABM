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
    Animator punched;
    Animator punch;
    void Awake()
    {
        menschLogoAnim = menschLogo.GetComponent<Animator>();
        phoneDown = Phone.GetComponent<Animator>();
        punched = Fist.GetComponent<Animator>();
        punch = CreepyDriver.GetComponent<Animator>();

        phoneDown = Phone.GetComponent<Animator>();
        punched = CreepyDriver.GetComponent<Animator>();
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
        phoneDown.SetTrigger("PhoneDown");
        punched.SetTrigger("Punched");
        punch.SetTrigger("Punch");
    }
}
