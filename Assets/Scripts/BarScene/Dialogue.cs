using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TextMeshPro textmesh;
    private Animator anim;
    private SpriteRenderer sr;

    void Awake()
    {
        textmesh = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
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
        if (anim.GetBool("Entered") == true)
        {
            anim.SetBool("Entered", false);
        }
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
        foreach (char c in dialogue.ToCharArray())
        {
            textmesh.text += c;
            float pauseTime = .02f;

            while (pauseTime > 0)
            {
                pauseTime -= Time.deltaTime;
                yield return null;
            }
        }
    }
}
