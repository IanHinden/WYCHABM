using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityBehavior : MonoBehaviour
{
    [SerializeField] GameObject city;

    Animator avaAnimator;
    Animator ppgAnimator;

    PittiePartyDialogue pittiePartyDialogue;

    TextMeshPro bigPittiesText;

    void Awake()
    {
        StartCoroutine(StartAnimations());

        avaAnimator = FindObjectOfType<Ava>().GetComponent<Animator>();
        ppgAnimator = FindObjectOfType<PittiePartyGirl>().GetComponent<Animator>();

        pittiePartyDialogue = FindObjectOfType<PittiePartyDialogue>();
        bigPittiesText = FindObjectOfType<BigPittiesText>().GetComponent<TextMeshPro>();
    }

    void Update()
    {
        
    }

    IEnumerator StartAnimations()
    {
        yield return new WaitForSeconds(2.5f);
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
    }
}
