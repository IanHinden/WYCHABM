using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landlord : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] GameObject landlord;
    [SerializeField] GameObject ava;

    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;

    Animator landlordAnim;
    Animator avaAnim;
    void Awake()
    {
        landlordAnim = landlord.GetComponent<Animator>();
        avaAnim = ava.GetComponent<Animator>();
        dialogue.transform.position = new Vector2(0, -6.5f);
        StartCoroutine(Dialogue());
    }

    private IEnumerator Dialogue()
    {
        landlordAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.6f);
        avaAnim.SetTrigger("Enter");
        dialogue.DialogueEnter();
        StartCoroutine(dialogue.SetDialogue("If you don't pay your rent by tomorrow, you are out of here!"));
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(4));
        uihandler.InstructionText("SELECT");
    }
}
