using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landlord : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    void Awake()
    {
        dialogue.transform.position = new Vector2(0, -6.5f);
        StartCoroutine(Dialogue());
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(.3f);
        dialogue.DialogueEnter();
        StartCoroutine(dialogue.SetDialogue("If you don't pay your rent by tomorrow, you are out of here!"));
        yield return new WaitForSeconds(2);
        dialogue.DialogueExit();
    }
}
