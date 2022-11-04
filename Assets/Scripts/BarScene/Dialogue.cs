using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TextMeshPro textmesh;
    private Animator anim;

    void Awake()
    {
        textmesh = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    public void DialogueEnter()
    {
        textmesh.text = "";
        anim.SetBool("Entered", true);
    }

    public void DialogueExit()
    {
        anim.SetBool("Entered", false);
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
