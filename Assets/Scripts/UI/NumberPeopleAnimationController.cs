using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPeopleAnimationController : MonoBehaviour
{
    [SerializeField] GameObject NP1;
    [SerializeField] GameObject NP2;

    Animator[] npAnimators = new Animator[10];

    private Animator NP1Anim;
    private Animator NP2Anim;

    void Awake()
    {
        NP1Anim = NP1.GetComponent<Animator>();
        NP2Anim = NP2.GetComponent<Animator>();

        npAnimators[0] = NP1Anim;
        npAnimators[1] = NP2Anim;
    }

    public void NPActivate(int np)
    {
        npAnimators[np - 1].SetTrigger("Unlock");
    }
}
