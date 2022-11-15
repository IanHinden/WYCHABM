using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityBehavior : MonoBehaviour
{
    [SerializeField] GameObject city;
    [SerializeField] GameObject avaObjects;
    [SerializeField] GameObject ava;
    [SerializeField] GameObject ppg;
    //[SerializeField] PittiePartyDialogue pittiePartyDialogue;
    [SerializeField] Dialogue dialogue;
    [SerializeField] TextMeshPro bigPittiesText;
    [SerializeField] UIHandler uihandler;

    Animator avaObjAnimator;
    Animator avaAnimator;
    Animator ppgAnimator;

    string[] dialogueText = new string[] {
        "Ugh... I am so ready for this shift to be over.",
        "You better collect your tips quickly...",
        "... before the manager takes his share.",
        "... I hate that guy."
    };

    void Awake()
    {
        StartCoroutine(StartAnimations());

        avaObjAnimator = avaObjects.GetComponent<Animator>();
        avaAnimator = ava.GetComponent<Animator>();
        ppgAnimator = ppg.GetComponent<Animator>();
    }

    IEnumerator StartAnimations()
    {
        yield return new WaitForSeconds(2.7f);
        city.SetActive(false);
        bigPittiesText.text = "";

        avaObjAnimator.SetTrigger("Enter");

        yield return new WaitForSeconds(.5f);
        dialogue.DialogueEnter();
        StartCoroutine(dialogue.SetDialogue(dialogueText[0]));
        yield return new WaitForSeconds(2f);
        dialogue.DialogueExit();
        ppgAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(1f);
        avaAnimator.SetTrigger("FadeOut");
        dialogue.DialogueEnter();
        StartCoroutine(dialogue.SetDialogue(dialogueText[1]));
        yield return new WaitForSeconds(2f);
        StartCoroutine(dialogue.SetDialogue(dialogueText[2]));
        yield return new WaitForSeconds(1f);
        dialogue.DialogueExit();
        yield return new WaitForSeconds(1f);
        dialogue.DialogueEnter();
        ppgAnimator.SetTrigger("Exit");
        avaAnimator.SetTrigger("FadeIn");
        StartCoroutine(dialogue.SetDialogue(dialogueText[3]));
        yield return new WaitForSeconds(2f);
        uihandler.InstructionText("COLLECT");
        dialogue.DialogueExit();
    }
}
