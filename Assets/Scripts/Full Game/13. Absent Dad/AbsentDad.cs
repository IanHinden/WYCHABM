using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsentDad : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;

    public IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(.3f);
        dialogue.DialogueEnter("DADDY");
        StartCoroutine(dialogue.SetDialogue("Tell mom I won't be home. Gotta work late."));
    }
}
