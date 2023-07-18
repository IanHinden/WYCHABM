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

    [SerializeField] GameObject lightning;
    SpriteRenderer lightningSR;

    SpriteRenderer landlordSR;
    SpriteRenderer avaSR;

    Animator landlordAnim;
    Animator avaAnim;

    private float flashTime = .04f;
    void Awake()
    {
        landlordAnim = landlord.GetComponent<Animator>();
        avaAnim = ava.GetComponent<Animator>();
        dialogue.transform.position = new Vector2(0, -6.5f);
        lightningSR = lightning.GetComponent<SpriteRenderer>();
        landlordSR = landlord.transform.Find("Landlord").GetComponent<SpriteRenderer>();
        avaSR = ava.transform.Find("Ava").GetComponent<SpriteRenderer>();
    }

    public IEnumerator Dialogue()
    {
        avaAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.6f);
        landlordAnim.SetTrigger("Enter");
        dialogue.DialogueEnter();
        StartCoroutine(dialogue.SetDialogue("Pay the rent or get out."));
        yield return new WaitForSeconds(.3f);
        StartCoroutine(LightningFlash());
    }

    public void Reset()
    {
        landlord.transform.position = new Vector3(-14.02f, -1.41f, 0);
        ava.transform.position = new Vector3(16.08f, .07f, 0);
    }

    //TODO This might need to go into a non-Awake function for reset
    private IEnumerator LightningFlash()
    {
        yield return new WaitForSeconds(.5f);
        lightningSR.color = new Color(1, 1, 1, 1);
        landlordSR.color = new Color(0, 0, 0, 1);
        avaSR.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(flashTime);
        lightningSR.color = new Color(1, 1, 1, 0);
        landlordSR.color = new Color(1, 1, 1, 1);
        avaSR.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(flashTime);
        lightningSR.color = new Color(1, 1, 1, 1);
        landlordSR.color = new Color(0, 0, 0, 1);
        avaSR.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(flashTime);
        lightningSR.color = new Color(1, 1, 1, 0);
        landlordSR.color = new Color(1, 1, 1, 1);
        avaSR.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(flashTime);
        lightningSR.color = new Color(1, 1, 1, 1);
        landlordSR.color = new Color(0, 0, 0, 1);
        avaSR.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(flashTime);
        lightningSR.color = new Color(1, 1, 1, 0);
        landlordSR.color = new Color(1, 1, 1, 1);
        avaSR.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(flashTime);
    }
}
