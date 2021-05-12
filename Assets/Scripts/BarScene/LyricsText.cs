using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LyricsText : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private float waitTime = 2;
    private string dialogue = "Rich man Richmond get the itch, man.";
    
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
        yield return new WaitForSeconds(waitTime);
        textmesh.text = "";

        foreach(char c in dialogue.ToCharArray())
        {
            textmesh.text += c;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
