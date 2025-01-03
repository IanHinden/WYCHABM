﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chorus1AnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;

    [SerializeField] InstructionsAnimationController instructionsAnimationController;

    [SerializeField] GameObject Chorus1Ava;
    [SerializeField] GameObject Chorus1RR;

    [SerializeField] GameObject Would;
    [SerializeField] GameObject You;
    [SerializeField] GameObject Call;
    [SerializeField] GameObject Him;
    [SerializeField] GameObject Badman;

    Animator Chorus1AvaAnim;
    Animator Chorus1RRAnim;
    Animator BadmanAnim;

    void Awake()
    {
        Chorus1AvaAnim = Chorus1Ava.GetComponent<Animator>();
        Chorus1RRAnim = Chorus1RR.GetComponent<Animator>();

        BadmanAnim = Badman.GetComponent<Animator>();
    }

    public void AnimationLogic()
    {
        StartCoroutine(CardAnimations());
        StartCoroutine(LyricsTimer());
        StartCoroutine(InstructionsTimer());
    }

    private IEnumerator CardAnimations()
    {
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure() * 2);
        Chorus1AvaAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(timeFunctions.ReturnSingleMeasure() * 4);
        Chorus1RRAnim.SetTrigger("Enter");
    }

    private IEnumerator LyricsTimer()
    {
        yield return new WaitForSeconds(7.25545f);
        Would.SetActive(true);
        yield return new WaitForSeconds(0.3358743f);
        You.SetActive(true);
        yield return new WaitForSeconds(0.1854832f);
        Call.SetActive(true);
        yield return new WaitForSeconds(0.1500647f);
        Him.SetActive(true);
        yield return new WaitForSeconds(0.2023925f);
        Badman.SetActive(true);
        BadmanAnim.Play("BadmanSlide");
        //yield return new WaitForSeconds(0.1945287f);
        //yield return new WaitForSeconds(0.5377512f);
        //yield return new WaitForSeconds(0.5015675f);
    }

    private IEnumerator InstructionsTimer()
    {
        yield return new WaitForSeconds(1f);
        instructionsAnimationController.OpenInstructionHolder();
        yield return new WaitForSeconds(1f);
        instructionsAnimationController.SetInstructionText();
        yield return new WaitForSeconds(2f);
        instructionsAnimationController.ClearInstructionText();
        yield return new WaitForSeconds(1f);
        instructionsAnimationController.CloseInstructionHolder();

    }

    public void Reset()
    {
        if (Chorus1AvaAnim != null)
        {
            instructionsAnimationController.Reset();

            Chorus1Ava.transform.position = new Vector3(-8.16f, -0.53f, 0f);
            Chorus1Ava.transform.eulerAngles = new Vector3(0, 0, 10);
            Chorus1AvaAnim.ResetTrigger("Enter");

            Chorus1RR.transform.position = new Vector3(8.69f, -0.49f, 0f);
            Chorus1RR.transform.eulerAngles = new Vector3(0, 0, 20);
            Chorus1RRAnim.ResetTrigger("Enter");

            Would.SetActive(false);
            You.SetActive(false);
            Call.SetActive(false);
            Him.SetActive(false);
            Badman.SetActive(false);
        }
    }
}
