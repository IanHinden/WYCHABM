using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPAnimationController : MonoBehaviour
{
    [SerializeField] GameObject NP1;

    private Animator NP1Anim;

    void Awake()
    {
        NP1Anim = NP1.GetComponent<Animator>();
    }
}
