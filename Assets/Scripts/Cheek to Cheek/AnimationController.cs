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

    private bool kissTriggered = false;
    private bool hitTriggered = false;

    private void Awake()
    {
        KissNeutralWifeAnim = KissNeutralWife.GetComponent<Animator>();
        LeafAnim = Leaf.GetComponent<Animator>();
        BrokenHeartAnim = BrokenHeart.GetComponent<Animator>();
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
}
