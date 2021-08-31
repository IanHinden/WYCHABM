using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MADAnimationController : MonoBehaviour
{
    Animator evilSmirkAnim;
    Animator dialogueBoxAnim;

    private TextMeshPro textmesh;
    private float waitTime = 2f;
    public string dialogue;
    void Awake()
    {
        evilSmirkAnim = FindObjectOfType<EvilSmirk>().GetComponent<Animator>();
        dialogueBoxAnim = FindObjectOfType<DialogueBox>().GetComponent<Animator>();
        textmesh = FindObjectOfType<BobDylan>().GetComponent<TextMeshPro>();
        StartCoroutine(TypeLyrics());

        evilSmirkAnim.SetTrigger("Enter");
        dialogueBoxAnim.SetTrigger("FadeIn");
    }

    IEnumerator TypeLyrics()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }

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
