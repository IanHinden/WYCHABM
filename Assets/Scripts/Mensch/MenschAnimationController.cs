using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschAnimationController : MonoBehaviour
{
    [SerializeField] GameObject menschLogo;
    [SerializeField] GameObject interactiveScreen;

    private SpriteRenderer menschLogoSR;

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

        menschLogoSR = menschLogo.GetComponent<SpriteRenderer>();
    }

    public void ScreenFade()
    {
        menschLogoAnim.SetTrigger("Fade");
    }

    public void ResetScreenFade()
    {
        menschLogoAnim.ResetTrigger("Fade");
        menschLogoSR.color = new Color(1, 1, 1, 0);
    }

    public void enableScreen()
    {
        interactiveScreen.SetActive(true);
    }

    public void playDriverKiss()
    {
        driverPunchedAnim.Play("DriverKiss");
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
        if (fingerAnim != false)
        {
            fingerAnim.enabled = true;
            interactiveScreen.SetActive(false);
            
            phoneDown.ResetTrigger("PhoneDown");
            fistPunchedAnim.ResetTrigger("Punched");
            driverPunchedAnim.ResetTrigger("Punched");
            fingerAnim.ResetTrigger("FingerDown");

            fingerAnim.enabled = false;
            //driverPunchedAnim.Play("DriverKiss");

            Fist.transform.position = new Vector3(6.3f, -9.14f, 0);
            Phone.transform.position = new Vector3(-1.39f, -0.06f, 0);
            
            ResetScreenFade();
        }

        //Possibly need to turn off Finger animator before I can enable controls again
        //Reset positions of everything
    }
}
