using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPeopleAnimationController : MonoBehaviour
{
    [SerializeField] GameObject NP1;

    Animator[] npAnimators = new Animator[10];

    private Animator NP1Anim;

    void Awake()
    {
        NP1Anim = NP1.GetComponent<Animator>();

        npAnimators[0] = NP1Anim;
    }

    public void NPActivate(int np)
    {
        npAnimators[np - 1].SetTrigger("Unlock");
    }
}
