using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EvolvingText : MonoBehaviour
{
    private TextMeshPro textmesh;

    private string evolvingDial = "What?                Bad Boy is evolving.";
    private string evolvedDial = "Bad Boy evolved into Bad Man.";
    private string stoppedDial = "Huh? Bad Boy stopped evolving. Arrested development.";
    void Awake()
    {
        textmesh = gameObject.GetComponent<TextMeshPro>();
    }

    public IEnumerator SetEvolvingDialogue()
    {

        foreach (char c in evolvingDial.ToCharArray())
        {
            textmesh.text += c;
            float pauseTime = .02f;

            while (pauseTime > 0)
            {
                pauseTime -= Time.deltaTime;
                yield return null;
            }
        }

        yield return new WaitForSeconds(2);

        textmesh.text = "";
        foreach (char c in evolvedDial.ToCharArray())
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

    public IEnumerator SetStoppedDialogue()
    {
        textmesh.text = "";
        foreach (char c in stoppedDial.ToCharArray())
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
