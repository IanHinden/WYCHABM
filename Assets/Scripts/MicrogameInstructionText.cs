﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MicrogameInstructionText : MonoBehaviour
{
    private TextMeshPro textmesh;
    private Animator anim;

    void Awake()
    {
        textmesh = this.gameObject.GetComponent<TextMeshPro>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void InstructionText(string instructions)
    {
        StartCoroutine(AnimateAndDestroy(instructions));
    }

    private IEnumerator AnimateAndDestroy(string instructions)
    {
        textmesh.text = instructions;
        anim.SetTrigger("StartAnim");
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
