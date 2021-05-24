using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EvolveText : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private float waitTime = 2.6f;
    private string dialogue = "BAD BOY evolved into BAD MAN!";

    void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeLyrics());
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

            yield return new WaitForSeconds(0.05f);
        }
    }
}
