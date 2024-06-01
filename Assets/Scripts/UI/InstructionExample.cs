using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionExample : MonoBehaviour
{
    private TextMeshProUGUI instructionText;
    private string[] instructionExamples = new string[4];
    private Animator showTextAnim;
    int curr = 0;
    private void Awake()
    {
        instructionText = this.gameObject.GetComponent<TextMeshProUGUI>();
        instructionExamples[0] = "COLLECT";
        instructionExamples[1] = "SELECT";
        instructionExamples[2] = "DRIVE";
        instructionExamples[3] = "AIM";

        showTextAnim = this.gameObject.GetComponent<Animator>();
    }

    private void InstructionSetText()
    {
        instructionText.text = instructionExamples[curr];
        curr++;
        if(curr > instructionExamples.Length - 1)
        {
            curr = 0;
        }
    }

    private void HideText()
    {
        instructionText.text = "";
    }

    public void TriggerAnimation()
    {
        showTextAnim.SetTrigger("ShowText");
    }

    public void ResetTrigger()
    {
        showTextAnim.Play("New State");
        showTextAnim.ResetTrigger("ShowText");
    }
}
