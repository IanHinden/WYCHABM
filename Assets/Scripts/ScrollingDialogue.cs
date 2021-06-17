using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingDialogue : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private float waitTime = 1f;
    public string dialogue;

    void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeLyrics());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TypeLyrics()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }

        textmesh.text = "MR. RICHMOND:";

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
