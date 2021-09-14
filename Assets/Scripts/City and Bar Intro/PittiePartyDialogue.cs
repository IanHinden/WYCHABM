using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PittiePartyDialogue : MonoBehaviour
{
    private TextMeshPro textmesh;

    public string dialogue;
    public string ppgdialogue;
    public string ppgdialoguetwo;
    public string dialoguetwo;
    void Awake()
    {
        textmesh = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
    }

    public IEnumerator SetAvaDialogue()
    {
        textmesh.text = "Ava: ";
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

    public IEnumerator SetPpgDialogue()
    {
        textmesh.text = "Luce: ";
        foreach (char c in ppgdialogue.ToCharArray())
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

    public IEnumerator SetPpgDialogueTwo()
    {
        textmesh.text = "Luce: ";
        foreach (char c in ppgdialoguetwo.ToCharArray())
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

    public IEnumerator SetAvaDialogueTwo()
    {
        textmesh.text = "Ava: ";
        foreach (char c in dialoguetwo.ToCharArray())
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
