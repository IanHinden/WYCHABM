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

    [Header("Audio Objects")]
    [SerializeField] CityAndBarSFX cityAndBarSFX;

    [Header("Dialog Objects")]
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

    Coroutine dialogue1;
    Coroutine dialogue2;
    Coroutine dialogue3;
    Coroutine dialogue4;

    string[] dialogueText = new string[] {
        "Ugh... I am so done today.",
        "The new girl doesn't know the manager  '",
        "'...",
        "Don't worry, Luce! I got this."
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
        dialogue.DialogueEnter("AVA");
        dialogue1 = StartCoroutine(dialogue.SetDialogue(dialogueText[0]));
        yield return new WaitForSeconds(2.2f);
        ppgAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(.3f);
        cityAndBarSFX.LucyEnter();
        dialogue.DialogueExit();
        yield return new WaitForSeconds(.5f);
        dialogue.DialogueEnter("LUCY");
        dialogue2 = StartCoroutine(dialogue.AvaNameEnter(dialogueText[1], dialogueText[2]));
        yield return new WaitForSeconds(2f);
        avaEyesClosed.enabled = false;
        avaEyesOpen.enabled = true;
        cityAndBarSFX.AvaBlink();
        yield return new WaitForSeconds(.2f);
        avaEyesClosed.enabled = true;
        avaEyesOpen.enabled = false;
        yield return new WaitForSeconds(.2f);
        avaEyesClosed.enabled = false;
        avaEyesOpen.enabled = true;
        cityAndBarSFX.AvaBlink();
        yield return new WaitForSeconds(2.35f);
        dialogue.DialogueExit();


        cityAndBarSFX.AvaProud();
        avaPos1.SetActive(false);
        avaPos2.SetActive(true);

        yield return new WaitForSeconds(.8f);
        lucyTalkingEyes.enabled = false;
        lucyStaringEyes.enabled = true;
        sweatAnimator.SetTrigger("SetSweat");


        dialogue.DialogueEnter("AVA");
        //ppgAnimator.SetTrigger("Exit");
        dialogue4 = StartCoroutine(dialogue.SetDialogue(dialogueText[3]));
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

        if(dialogue1 != null) { StopCoroutine(dialogue1); }
        if(dialogue2 != null) { StopCoroutine(dialogue2); }
        if(dialogue3 != null) { StopCoroutine(dialogue3); }
        if(dialogue4 != null) { StopCoroutine(dialogue4); }

        city.transform.position = new Vector2(3.68f, 2.09f);
        avaObjects.transform.position = new Vector2(-16.68f, .86f);
        ppg.transform.position = new Vector2(40.71f, 1.53f);
    }
}
