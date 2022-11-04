using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsentDad : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    void Awake()
    {
        dialogue.transform.position = new Vector2(0, -6.5f);
        StartCoroutine(Dialogue());
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(.3f);
        dialogue.DialogueEnter();
        StartCoroutine(dialogue.SetDialogue("Sorry, kiddo. Tell mom I won't be home. I got a lot of work to finish at the office. "));
    }
}
