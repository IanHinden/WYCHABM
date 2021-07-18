﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator heartAnim;
    Rigidbody2D richmondLipsRB;
    Rigidbody2D missusRB;

    Animator leftHeart;
    Animator rightHeart;

    SpankArm spankArm;
    Animator spankMark;

    private bool kissTriggered = false;
    private bool hitTriggered = false;

    void Awake()
    {
        heartAnim = FindObjectOfType<Heart>().GetComponent<Animator>();
        richmondLipsRB = FindObjectOfType<RichmondLips>().GetComponent<Rigidbody2D>();
        missusRB = FindObjectOfType<Missus>().GetComponent<Rigidbody2D>();
        spankArm = FindObjectOfType<SpankArm>();
        spankMark = FindObjectOfType<SpankMark>().GetComponent<Animator>();
        leftHeart = FindObjectOfType<LeftHeart>().GetComponent<Animator>();
        rightHeart = FindObjectOfType<RightHeart>().GetComponent<Animator>();
    }

    void Update()
    {
        spankArm.Spank();
    }

    public void KissWinAnimation()
    {
        if (kissTriggered == false)
        {
            heartAnim.SetTrigger("Success");
            StartCoroutine(KissMove());
            kissTriggered = true;
        }
    }

    private IEnumerator KissMove()
    {
        richmondLipsRB.velocity = transform.right * -2;
        yield return new WaitForSeconds(.5f);
        richmondLipsRB.velocity = Vector3.zero;
        yield return null;
    }

    public void KissLoseAnimation()
    {
        if (kissTriggered == false)
        {
            StartCoroutine(MissMove());
            leftHeart.SetTrigger("Break");
            rightHeart.SetTrigger("Break");
            kissTriggered = true;
        }
    }

    private IEnumerator MissMove()
    {
        missusRB.velocity = transform.right * -5;
        yield return null;
    }

    public void HitWinAnimation()
    {
        if(hitTriggered == false){
            spankArm.StartSpank();
            spankMark.SetTrigger("Spank");
            hitTriggered = true;
        }
    }
}
