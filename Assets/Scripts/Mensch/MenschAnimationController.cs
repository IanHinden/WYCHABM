using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschAnimationController : MonoBehaviour
{
    Animator blackScreenAnimator;
    Animator menschLogoAnimator;
    Animator menschTextAnimator;
    void Awake()
    {
        blackScreenAnimator = FindObjectOfType<BlackScreen>().GetComponent<Animator>();
        menschLogoAnimator = FindObjectOfType<MenschLogo>().GetComponent<Animator>();
        menschTextAnimator = FindObjectOfType<MenschText>().GetComponent<Animator>();
    }

    public void ScreenFade()
    {
        blackScreenAnimator.SetTrigger("FadeOut");
        menschLogoAnimator.SetTrigger("FadeOut");
        menschTextAnimator.SetTrigger("FadeOut");
    }
}
