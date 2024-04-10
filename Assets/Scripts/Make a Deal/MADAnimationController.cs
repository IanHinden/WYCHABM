using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MADAnimationController : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    void Awake()
    {
        //StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1.5f);
        dialogue.DialogueEnter("R.R. Jr.");
        StartCoroutine(dialogue.SetDialogue("Would you like to...                                                                                  make a deal?"));
    }
}
