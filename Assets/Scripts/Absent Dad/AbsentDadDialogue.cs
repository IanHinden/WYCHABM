using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbsentDadDialogue : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private float waitTime = 1f;
    private string dialogue = "Sorry, kiddo. Tell mom I won't be home. I got a lot of work to finish at the office. ";

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

            yield return new WaitForSeconds(0.05f);
        }
    }
}
