using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschAnimationController : MonoBehaviour
{
    Animator blackScreenAnimator;
    Animator menschLogoAnimator;
    Animator menschTextAnimator;
    Animator safetyAnimator;
    Animator statusAnimator;
    void Awake()
    {
        blackScreenAnimator = FindObjectOfType<BlackScreen>().GetComponent<Animator>();
        menschLogoAnimator = FindObjectOfType<MenschLogo>().GetComponent<Animator>();
        menschTextAnimator = FindObjectOfType<MenschText>().GetComponent<Animator>();
        safetyAnimator = FindObjectOfType<Safety>().GetComponent<Animator>();
        statusAnimator = FindObjectOfType<Status>().GetComponent<Animator>();
    }

    public void ScreenFade()
    {
        blackScreenAnimator.SetTrigger("FadeOut");
        menschLogoAnimator.SetTrigger("FadeOut");
        menschTextAnimator.SetTrigger("FadeOut");
    }

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
}
