using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PittiePartyDialogue : MonoBehaviour
{
    private TextMeshPro textmesh;

    public string dialogue;
    void Awake()
    {
        textmesh = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
    }

    public IEnumerator SetAvaDialogue()
    {
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

    void Update()
    {
        
    }
}
