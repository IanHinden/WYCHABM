using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TextMeshPro textmesh;
    private TextMeshPro avaNameDialogueText;

    [SerializeField] GameObject splitTips;

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

    public void DialogueExit()
    {
        anim.SetBool("Entered", false);
        ResetSplitTips();
    }

    public void QuickExit()
    {
        textmesh.text = "";
        sr.enabled = false;
        DialogueExit();
        ResetSplitTips();
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

    public IEnumerator AvaNameEnter(string dialogue, string dialogue2)
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

        StartCoroutine(SplitTipsText());

        textmesh.text += "                   ";

        foreach (char c in dialogue2.ToCharArray())
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

    private IEnumerator SplitTipsText()
    {
        for (int i = 0; i < splitTips.transform.childCount; i++)
        {
            splitTips.transform.GetChild(i).gameObject.SetActive(true);
            Animator letterAnim = splitTips.transform.GetChild(i).GetComponent<Animator>();
            letterAnim.Play("s");
            yield return new WaitForSeconds(.01f);
        }
    }

    private void ResetSplitTips()
    {
        for (int i = 0; i < splitTips.transform.childCount; i++)
        {
            if (splitTips.transform.GetChild(i).gameObject.activeInHierarchy == true)
            {
                Animator letterAnim = splitTips.transform.GetChild(i).GetComponent<Animator>();
                letterAnim.Play("New State");
                splitTips.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void Reset()
    {
        QuickExit();
        avaNameDialogueText.text = "";
        avaNameDialogueAnim.Play("New State");

        for (int i = 0; i < splitTips.transform.childCount; i++)
        {
            splitTips.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
