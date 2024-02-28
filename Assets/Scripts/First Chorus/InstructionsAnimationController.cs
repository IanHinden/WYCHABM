using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionsAnimationController : MonoBehaviour
{
    [SerializeField] GameObject chorusInstructionsHolder;
    [SerializeField] TextMeshProUGUI instructionText;

    private Animator chorusInstructionsHolderAnim;
    //private Image chorusInstructionsHolderImage;

    private void Awake()
    {
        chorusInstructionsHolderAnim = chorusInstructionsHolder.GetComponent<Animator>();
    }

    public void OpenInstructionHolder()
    {
        chorusInstructionsHolderAnim.SetBool("Open", true);
    }

    public void CloseInstructionHolder()
    {
        chorusInstructionsHolderAnim.SetBool("Open", false);
    }

    public void ClearInstructionText()
    {
        instructionText.text = "";
    }

    public void SetInstructionText()
    {
        instructionText.text = "PRESS KEYS IN TIME WITH LYRICS";
    }

    public void Reset()
    {
        if (chorusInstructionsHolderAnim != null)
        {
            CloseInstructionHolder();
            ClearInstructionText();
        }
    }
}
