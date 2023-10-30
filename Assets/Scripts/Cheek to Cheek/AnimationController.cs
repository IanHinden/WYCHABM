﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Kiss Objects")]
    [SerializeField] GameObject KissObjects;
    [SerializeField] GameObject KissObjectsNeutral;
    [SerializeField] GameObject KissObjectsWin;
    [SerializeField] GameObject KissObjectLose;

    [SerializeField] GameObject KissNeutralWife;

    [SerializeField] GameObject Leaf;
    [SerializeField] GameObject BrokenHeart;

    Animator KissScenarioEndAnim;
    Animator KissNeutralWifeAnim;
    Animator LeafAnim;
    Animator BrokenHeartAnim;

    [Header("Hit Objects")]
    [SerializeField] GameObject MistressObjects;
    [SerializeField] GameObject MistressObjectsNeutral;
    [SerializeField] GameObject MistressObjectsWin;
    [SerializeField] GameObject MistressObjectsLose;
    [SerializeField] GameObject Bruise;
    [SerializeField] GameObject Hands;
    [SerializeField] GameObject HandsWin1;
    [SerializeField] GameObject HandsWin2;
    [SerializeField] GameObject SlapWaves;
    [SerializeField] GameObject FaceSmile;
    [SerializeField] GameObject FaceWink;
    [SerializeField] GameObject HandsLose;

    SpriteRenderer BruiseSR;
    SpriteRenderer HandsWin1SR;
    SpriteRenderer HandsWin2SR;
    SpriteRenderer SlapWavesSR;
    SpriteRenderer FaceSmileSR;
    SpriteRenderer FaceWinkSR;

    Animator MissScenarioBeginAnim;
    Animator SlapAnim;
    Animator HandsLoseAnim;

    private bool kissTriggered = false;
    private bool hitTriggered = false;

    private void Awake()
    {
        KissScenarioEndAnim = KissObjects.GetComponent<Animator>();
        KissNeutralWifeAnim = KissNeutralWife.GetComponent<Animator>();
        LeafAnim = Leaf.GetComponent<Animator>();
        BrokenHeartAnim = BrokenHeart.GetComponent<Animator>();

        BruiseSR = Bruise.GetComponent<SpriteRenderer>();
        HandsWin1SR = HandsWin1.GetComponent<SpriteRenderer>();
        HandsWin2SR = HandsWin2.GetComponent<SpriteRenderer>();
        SlapWavesSR = SlapWaves.GetComponent<SpriteRenderer>();

        FaceSmileSR = FaceSmile.GetComponent<SpriteRenderer>();
        FaceWinkSR = FaceWink.GetComponent<SpriteRenderer>();

        MissScenarioBeginAnim = MistressObjects.GetComponent<Animator>();
        SlapAnim = Hands.GetComponent<Animator>();
        HandsLoseAnim = HandsLose.GetComponent<Animator>();
    }

    public void SwitchScene()
    {
        KissScenarioEndAnim.SetTrigger("Switch");
        MissScenarioBeginAnim.SetTrigger("Switch");
    }

    public void KissWin()
    {
        KissObjectsNeutral.SetActive(false);
        KissObjectsWin.SetActive(true);
    }

    public void KissLose()
    {
        KissNeutralWifeAnim.SetTrigger("Exit");
        KissObjectLose.SetActive(true);
        BrokenHeartAnim.SetTrigger("Break");
        LeafAnim.SetTrigger("Blow");
    }

    public void MisstressWin()
    {
        StartCoroutine(MisstressWinAppearances());
        MistressObjectsNeutral.SetActive(false);
        MistressObjectsWin.SetActive(true);

        SlapAnim.SetTrigger("Slap");
    }

    public void MisstressLose()
    {
        MistressObjectsNeutral.SetActive(false);
        MistressObjectsLose.SetActive(true);
        HandsLoseAnim.SetTrigger("HandsLose");
    }

    private IEnumerator MisstressWinAppearances()
    {
        yield return new WaitForSeconds(.3f);

        HandsWin1SR.enabled = false;
        HandsWin2SR.enabled = true;

        BruiseSR.enabled = true;

        SlapWavesSR.enabled = true;

        yield return new WaitForSeconds(.2f);
        FaceSmileSR.enabled = false;
        FaceWinkSR.enabled = true;

    }

    public void Reset()
    {
        // MistressWin
        HandsWin1SR.enabled = true;
        HandsWin2SR.enabled = false;
        BruiseSR.enabled = false;
        SlapWavesSR.enabled = false;
        FaceSmileSR.enabled = true;
        FaceWinkSR.enabled = false;
        HandsLoseAnim.ResetTrigger("HandsLose");
    }
}
