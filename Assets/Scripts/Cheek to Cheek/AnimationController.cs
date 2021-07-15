using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator heartAnim;

    void Awake()
    {
        heartAnim = FindObjectOfType<Heart>().GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void KissWinAnimation()
    {
        heartAnim.SetTrigger("Success");
    }
}
