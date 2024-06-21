using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScene : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;

    void Awake()
    {
        //StartCoroutine(Dialogue());
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(2);
        dialogue.DialogueEnter("IAN H.");
        yield return new WaitForSeconds(1);
        //StartCoroutine(dialogue.SetDialogue("Rich man Richmond get the itch, man"));
    }
}
