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
    [SerializeField] GameObject puff;
    //[SerializeField] PittiePartyDialogue pittiePartyDialogue;
    [SerializeField] Dialogue dialogue;
    [SerializeField] TextMeshPro bigPittiesText;
    [SerializeField] UIHandler uihandler;

    Animator avaObjAnimator;
    Animator avaAnimator;
    Animator ppgAnimator;
    Animator puffAnimator;

    SpriteRenderer avaEyesClosed;

    string[] dialogueText = new string[] {
        "Ugh... I am so ready for this shift to be over.",
        "Ava, you know the new girl?",
        "... She doesn't know the manager 'splits tips'.",
        "Don't worry, I'll take care of it."
    };

    void Awake()
    {
        StartCoroutine(StartAnimations());

        avaObjAnimator = avaObjects.GetComponent<Animator>();
        avaAnimator = ava.GetComponent<Animator>();
        ppgAnimator = ppg.GetComponent<Animator>();
        puffAnimator = puff.GetComponent<Animator>();

        avaEyesClosed = ava.GetComponent<SpriteRenderer>();
    }

    IEnumerator StartAnimations()
    {
        yield return new WaitForSeconds(2.7f);
        city.SetActive(false);
        bigPittiesText.text = "";

        avaObjAnimator.SetTrigger("Enter");

        yield return new WaitForSeconds(.5f);
        puffAnimator.SetTrigger("TriggerPuff");
        dialogue.DialogueEnter();
        StartCoroutine(dialogue.SetDialogue(dialogueText[0]));
        yield return new WaitForSeconds(2.7f);
        dialogue.DialogueExit();
        ppgAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(.3f);
        avaAnimator.SetTrigger("FadeOut");
        dialogue.DialogueEnter();
        avaEyesClosed.enabled = false;
        StartCoroutine(dialogue.SetDialogue(dialogueText[1]));
        yield return new WaitForSeconds(2f);
        StartCoroutine(dialogue.SetDialogue(dialogueText[2]));
        yield return new WaitForSeconds(1.7f);
        dialogue.DialogueExit();
        yield return new WaitForSeconds(.3f);
        dialogue.DialogueEnter();
        ppgAnimator.SetTrigger("Exit");
        avaAnimator.SetTrigger("FadeIn");
        StartCoroutine(dialogue.SetDialogue(dialogueText[3]));
    }
}
