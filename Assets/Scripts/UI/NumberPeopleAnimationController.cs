using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPeopleAnimationController : MonoBehaviour
{
    [SerializeField] GameObject NP1;
    [SerializeField] GameObject NP2;
    [SerializeField] GameObject NP3;
    [SerializeField] GameObject NP4;
    [SerializeField] GameObject NP5;
    [SerializeField] GameObject NP6;
    [SerializeField] GameObject NP7;
    [SerializeField] GameObject NP8;
    [SerializeField] GameObject NP9;
    [SerializeField] GameObject NP10;

    Animator[] npAnimators = new Animator[10];

    private Animator NP1Anim;
    private Animator NP2Anim;
    private Animator NP3Anim;
    private Animator NP4Anim;
    private Animator NP5Anim;
    private Animator NP6Anim;
    private Animator NP7Anim;
    private Animator NP8Anim;
    private Animator NP9Anim;
    private Animator NP10Anim;

    void Awake()
    {
        NP1Anim = NP1.GetComponent<Animator>();
        NP2Anim = NP2.GetComponent<Animator>();
        NP3Anim = NP3.GetComponent<Animator>();
        NP4Anim = NP4.GetComponent<Animator>();
        NP5Anim = NP5.GetComponent<Animator>();
        NP6Anim = NP6.GetComponent<Animator>();
        NP7Anim = NP7.GetComponent<Animator>();
        NP8Anim = NP8.GetComponent<Animator>();
        NP9Anim = NP9.GetComponent<Animator>();
        NP10Anim = NP10.GetComponent<Animator>();

        npAnimators[0] = NP1Anim;
        npAnimators[1] = NP2Anim;
        npAnimators[2] = NP3Anim;
        npAnimators[3] = NP4Anim;
        npAnimators[4] = NP5Anim;
        npAnimators[5] = NP6Anim;
        npAnimators[6] = NP7Anim;
        npAnimators[7] = NP8Anim;
        npAnimators[8] = NP9Anim;
        npAnimators[9] = NP10Anim;
    }

    public void NPActivate(int np)
    {
        npAnimators[np - 1].SetTrigger("Unlock");
    }
}
