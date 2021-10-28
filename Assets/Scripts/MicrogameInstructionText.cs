using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MicrogameInstructionText : MonoBehaviour
{
    private TextMeshPro textmesh;
    private Animator anim;

    [SerializeField] string instructions;
    void Awake()
    {
        textmesh = this.gameObject.GetComponent<TextMeshPro>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void InstructionText()
    {
        textmesh.text = instructions;
        anim.SetTrigger("StartAnim");
    }
}
