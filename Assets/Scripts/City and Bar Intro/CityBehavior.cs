using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityBehavior : MonoBehaviour
{
    [SerializeField] GameObject city;

    [Header("Ava Objects")]
    [SerializeField] GameObject avaObjects;
    [SerializeField] GameObject avaPos1;
    [SerializeField] GameObject closedEyes;
    [SerializeField] GameObject openEyes;
    [SerializeField] GameObject avaPos2;
    [SerializeField] GameObject puff;

    [Header("Lucy Objects")]
    [SerializeField] GameObject ppg;
    [SerializeField] GameObject talkingEyes;
    [SerializeField] GameObject staringEyes;
    [SerializeField] GameObject sweatDrop;
    
    //[SerializeField] PittiePartyDialogue pittiePartyDialogue;
    [SerializeField] Dialogue dialogue;
    [SerializeField] TextMeshPro bigPittiesText;
    [SerializeField] UIHandler uihandler;

    Animator avaObjAnimator;
    //Animator avaAnimator;
    Animator ppgAnimator;
    Animator puffAnimator;
    Animator sweatAnimator;

    SpriteRenderer avaEyesClosed;
    SpriteRenderer avaEyesOpen;

    SpriteRenderer lucyTalkingEyes;
    SpriteRenderer lucyStaringEyes;

    int activeRoutine = 0;

    Coroutine dialogue1;
    Coroutine dialogue2;
    Coroutine dialogue3;
    Coroutine dialogue4;

    string[] dialogueText = new string[] {
        "Ugh... I am so ready for this shift to be over.",
        "Ava, you know the new girl?",
        "... She doesn't know the manager 'splits tips'.",
        "Don't worry, I'll take care of it."
    };

    void Awake()
    {
        //StartCoroutine(StartAnimations());

        avaObjAnimator = avaObjects.GetComponent<Animator>();
        ppgAnimator = ppg.GetComponent<Animator>();
        puffAnimator = puff.GetComponent<Animator>();
        sweatAnimator = sweatDrop.GetComponent<Animator>();

        avaEyesClosed = closedEyes.GetComponent<SpriteRenderer>();
        avaEyesOpen = openEyes.GetComponent<SpriteRenderer>();

        lucyTalkingEyes = talkingEyes.GetComponent<SpriteRenderer>();
        lucyStaringEyes = staringEyes.GetComponent<SpriteRenderer>();
    }

    public IEnumerator StartAnimations()
    {
        yield return new WaitForSeconds(2.7f);
        city.SetActive(false);
        bigPittiesText.text = "";

        avaObjAnimator.SetTrigger("Enter");

        yield return new WaitForSeconds(.5f);
        puffAnimator.SetTrigger("TriggerPuff");
        dialogue.DialogueEnter();
        dialogue1 = StartCoroutine(dialogue.SetDialogue(dialogueText[0]));
        activeRoutine = 1;
        yield return new WaitForSeconds(2.7f);
        dialogue.DialogueExit();
        ppgAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(.3f);
        dialogue.DialogueEnter();
        avaEyesClosed.enabled = false;
        avaEyesOpen.enabled = true;
        dialogue2 = StartCoroutine(dialogue.SetDialogue(dialogueText[1]));
        activeRoutine = 2;
        yield return new WaitForSeconds(2f);
        dialogue3 = StartCoroutine(dialogue.SetDialogue(dialogueText[2]));
        activeRoutine = 3;
        yield return new WaitForSeconds(1.7f);
        dialogue.DialogueExit();
        yield return new WaitForSeconds(.3f);

        lucyTalkingEyes.enabled = false;
        lucyStaringEyes.enabled = true;
        avaPos1.SetActive(false);
        avaPos2.SetActive(true);
        sweatAnimator.SetTrigger("SetSweat");


        dialogue.DialogueEnter();
        //ppgAnimator.SetTrigger("Exit");
        dialogue4 = StartCoroutine(dialogue.SetDialogue(dialogueText[3]));
        activeRoutine = 4;
    }

    public void Reset()
    {
        bigPittiesText.text = "";
        city.SetActive(true);
        avaEyesClosed.enabled = true;
        dialogue.DialogueExit();

        avaPos1.SetActive(true);
        avaPos2.SetActive(false);
        avaEyesClosed.enabled = true;
        avaEyesOpen.enabled = false;

        lucyTalkingEyes.enabled = true;
        lucyStaringEyes.enabled = false;
        sweatDrop.transform.position = new Vector3(0f, .83f, 0f);
        sweatDrop.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);

        if (activeRoutine == 1)
        {
            StopCoroutine(dialogue1);
        }
        else if (activeRoutine == 2)
        {
            StopCoroutine(dialogue2);
        }
        else if (activeRoutine == 3)
        {
            StopCoroutine(dialogue3);
        }
        else if (activeRoutine == 4)
        {
            StopCoroutine(dialogue4);
        }

        city.transform.position = new Vector2(3.68f, 2.09f);
        avaObjects.transform.position = new Vector2(-16.68f, .86f);
        ppg.transform.position = new Vector2(40.71f, 1.53f);

        activeRoutine = 0;
    }
}
