/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionTextSetter : MonoBehaviour
{
    private Animator anim;
    private TextMeshProUGUI textmesh;
    private MicrogameInstructionText microText;

    [SerializeField] string instructions;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        textmesh = GetComponent<TextMeshProUGUI>();
        //StartCoroutine(InstructionText());
    }

    public void InstructionText()
    {
        //textmesh.text = instructions;
        //anim.SetTrigger("StartAnim");
        microText.InstructionText();
    }
}
*/