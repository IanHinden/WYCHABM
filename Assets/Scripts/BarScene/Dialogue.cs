using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TextMeshPro textmesh;
    private TextMeshPro avaNameDialogueText;

    private Animator anim;
    private Animator avaNameDialogueAnim;
    private SpriteRenderer sr;

    void Awake()
    {
        textmesh = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        avaNameDialogueText = this.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();

        avaNameDialogueAnim = avaNameDialogueText.GetComponent<Animator>();

        anim = this.gameObject.GetComponent<Animator>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void DialogueEnter()
    {
        sr.enabled = true;
        textmesh.text = "";
        anim.SetBool("Entered", true);
    }

    public IEnumerator AvaNameEnter(string dialogue)
    {
        AvaTextShake();
        textmesh.text = "          ";

        yield return new WaitForSeconds(.8f);

        foreach (char c in dialogue.ToCharArray())
        {
            textmesh.text += c;
            float pauseTime = .01f;

            while (pauseTime > 0)
            {
                pauseTime -= Time.deltaTime;
                yield return null;
            }
        }
    }

    private void AvaTextShake()
    {
        avaNameDialogueText.text = "AVA!";
        avaNameDialogueAnim.Play("AvaNameDialogue");
    }

    public void DialogueExit()
    {
        anim.SetBool("Entered", false);
    }

    public void QuickExit()
    {
        textmesh.text = "";
        sr.enabled = false;
        DialogueExit();
    }

    public IEnumerator SetDialogue(string dialogue)
    {
        textmesh.text = "";
        avaNameDialogueText.text = "";
        foreach (char c in dialogue.ToCharArray())
        {
            textmesh.text += c;
            float pauseTime = .01f;

            while (pauseTime > 0)
            {
                pauseTime -= Time.deltaTime;
                yield return null;
            }
        }
    }

    public void Reset()
    {
        QuickExit();
        avaNameDialogueText.text = "";
        avaNameDialogueAnim.Play("New State");
    }
}
