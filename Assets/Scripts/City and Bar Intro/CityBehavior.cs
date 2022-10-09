using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityBehavior : MonoBehaviour
{
    [SerializeField] GameObject city;
    [SerializeField] GameObject ava;
    [SerializeField] GameObject ppg;
    [SerializeField] PittiePartyDialogue pittiePartyDialogue;
    [SerializeField] TextMeshPro bigPittiesText;
    [SerializeField] UIHandler uihandler;

    Animator avaAnimator;
    Animator ppgAnimator;

    void Awake()
    {
        StartCoroutine(StartAnimations());

        avaAnimator = ava.GetComponent<Animator>();
        ppgAnimator = ppg.GetComponent<Animator>();
    }

    IEnumerator StartAnimations()
    {
        yield return new WaitForSeconds(2.7f);
        city.SetActive(false);
        bigPittiesText.text = "";

        avaAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(.5f);
        StartCoroutine(pittiePartyDialogue.SetAvaDialogue());
        yield return new WaitForSeconds(2f);
        ppgAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(1f);
        avaAnimator.SetTrigger("FadeOut");
        StartCoroutine(pittiePartyDialogue.SetPpgDialogue());
        yield return new WaitForSeconds(2f);
        StartCoroutine(pittiePartyDialogue.SetPpgDialogueTwo());
        yield return new WaitForSeconds(2f);
        ppgAnimator.SetTrigger("Exit");
        avaAnimator.SetTrigger("FadeIn");
        StartCoroutine(pittiePartyDialogue.SetAvaDialogueTwo());
        yield return new WaitForSeconds(2f);
        uihandler.InstructionText("COLLECT");
    }
}
