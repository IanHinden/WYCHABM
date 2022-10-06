using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textmesh;
    private Animator anim;

    void Awake()
    {
        textmesh.text = "";
        anim = textmesh.GetComponent<Animator>();
    }

    public void InstructionText(string instructions)
    {
        StartCoroutine(AnimateAndDestroy(instructions));
    }

    private IEnumerator AnimateAndDestroy(string instructions)
    {
        anim.SetTrigger("StartAnim");
        yield return new WaitForSeconds(.6f);
        textmesh.text = instructions;
        yield return new WaitForSeconds(3f);
        textmesh.text = "";
    }
}
