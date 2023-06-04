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
        //StartCoroutine(Dialogue());
    }

    public IEnumerator Dialogue()
    {
        landlordAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.6f);
        avaAnim.SetTrigger("Enter");
        dialogue.DialogueEnter();
        StartCoroutine(dialogue.SetDialogue("Pay the rent or get out."));
    }

    public void Reset()
    {
        landlord.transform.position = new Vector3(-14.02f, -1.41f, 0);
        ava.transform.position = new Vector3(11.42f, -1.82f, 0);
    }
}
