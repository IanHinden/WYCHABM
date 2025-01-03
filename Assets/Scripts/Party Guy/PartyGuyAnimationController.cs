﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyGuyAnimationController : MonoBehaviour
{
    [SerializeField] PartyGuySFX partyGuySFX;

    [SerializeField] GameObject bP2NiteText;
    [SerializeField] GameObject hellYeahText;
    [SerializeField] GameObject deliveredText;

    [SerializeField] Bubble bubble;

    SpriteRenderer deliveredTextSR;

    Animator bP2NiteTextAnim;
    Animator hellYeahTextAnim;
    Animator bubbleAnim;
    void Awake()
    {
        deliveredTextSR = deliveredText.GetComponent<SpriteRenderer>();

        bP2NiteTextAnim = bP2NiteText.GetComponent<Animator>();
        hellYeahTextAnim = hellYeahText.GetComponent<Animator>();

        bubbleAnim = bubble.GetComponent<Animator>();
    }

    public void sendBP2NiteText()
    {
        partyGuySFX.PlayTextBubble();
        bP2NiteTextAnim.SetTrigger("TextAppear");
    }

    public void sendHellYeahText()
    {
        partyGuySFX.PlayTextBubble();
        hellYeahTextAnim.SetTrigger("TextAppear");
    }

    public void setDeliveredText(bool setVisible)
    {
        if(deliveredTextSR != null) deliveredTextSR.enabled = setVisible;
    }

    public void SnotBubble()
    {
        bubbleAnim.SetBool("Bubble", true);
    }

    public void Reset()
    {
        setDeliveredText(false);

        bubble.Reset();

        if(bP2NiteTextAnim != null) bP2NiteTextAnim.ResetTrigger("TextAppear");
        if(hellYeahTextAnim != null) hellYeahTextAnim.ResetTrigger("TextAppear");

        if(bubbleAnim != null) bubbleAnim.SetBool("Bubble", false);

        bP2NiteText.transform.position = new Vector3(2.32f, 0.62f, 0f);
        bP2NiteText.transform.localScale = new Vector3(0.4632813f, 0, .4632813f);

        hellYeahText.transform.position = new Vector3(6.61f, -1.44f, 0f);
        hellYeahText.transform.localScale = new Vector3(0.4632813f, 0, 0.4632813f);
    }
}
