using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Kiss Objects")]
    [SerializeField] GameObject KissObjectsNeutral;
    [SerializeField] GameObject KissObjectsWin;
    [SerializeField] GameObject KissObjectLose;

    [SerializeField] GameObject KissNeutralWife;

    [SerializeField] GameObject Leaf;
    [SerializeField] GameObject BrokenHeart;

    Animator KissNeutralWifeAnim;
    Animator LeafAnim;
    Animator BrokenHeartAnim;

    [Header("Hit Objects")]
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

    Animator SlapAnim;

    private bool kissTriggered = false;
    private bool hitTriggered = false;

    private void Awake()
    {
        KissNeutralWifeAnim = KissNeutralWife.GetComponent<Animator>();
        LeafAnim = Leaf.GetComponent<Animator>();
        BrokenHeartAnim = BrokenHeart.GetComponent<Animator>();

        BruiseSR = Bruise.GetComponent<SpriteRenderer>();
        HandsWin1SR = HandsWin1.GetComponent<SpriteRenderer>();
        HandsWin2SR = HandsWin2.GetComponent<SpriteRenderer>();

        SlapAnim = Hands.GetComponent<Animator>();
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
}
