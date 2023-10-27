using System.Collections;
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

    SpriteRenderer BruiseSR;
    SpriteRenderer HandsWin1SR;
    SpriteRenderer HandsWin2SR;

    Animator MissScenarioBeginAnim;
    Animator SlapAnim;

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

        MissScenarioBeginAnim = MistressObjects.GetComponent<Animator>();
        SlapAnim = Hands.GetComponent<Animator>();
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
        MistressObjectsNeutral.SetActive(false);
        MistressObjectsWin.SetActive(true);

        SlapAnim.SetTrigger("Slap");
    }

    public void MisstressLose()
    {
        MistressObjectsNeutral.SetActive(false);
        MistressObjectsLose.SetActive(true);
    }
}
