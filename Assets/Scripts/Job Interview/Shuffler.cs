using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shuffler : MonoBehaviour
{
    private SpeechBubble[] speechBubbles;
    // Start is called before the first frame update
    void Awake()
    {
        speechBubbles = FindObjectsOfType<SpeechBubble>().OrderBy(m => m.transform.position.x).ToArray();
        //speechBubbles[1].transform.SetSiblingIndex(0);
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(4);
        speechBubbles[0].GetComponent<Animator>().SetTrigger("BottomToMid");
        speechBubbles[1].GetComponent<Animator>().SetTrigger("MidToTop");
        speechBubbles[2].GetComponent<Animator>().SetTrigger("TopToBottom");
        speechBubbles[1].transform.SetSiblingIndex(2);
        speechBubbles[0].transform.SetSiblingIndex(1);

        yield return new WaitForSeconds(4);
        Debug.Log("2nd time");
        speechBubbles = FindObjectsOfType<SpeechBubble>().OrderBy(m => m.transform.position.x).ToArray();
        speechBubbles[0].GetComponent<Animator>().SetTrigger("BottomToMid");
        speechBubbles[1].GetComponent<Animator>().SetTrigger("MidToTop");
        speechBubbles[2].GetComponent<Animator>().SetTrigger("TopToBottom");
        speechBubbles[1].transform.SetSiblingIndex(2);
        speechBubbles[0].transform.SetSiblingIndex(1);
    }

    private void ShuffleLeft()
    {
        speechBubbles = FindObjectsOfType<SpeechBubble>().OrderBy(m => m.transform.position.x).ToArray();
        speechBubbles[0].GetComponent<Animator>().SetTrigger("BottomToTop");
        speechBubbles[1].GetComponent<Animator>().SetTrigger("MidToBottom");
        speechBubbles[2].GetComponent<Animator>().SetTrigger("TopToMid");
        speechBubbles[0].transform.SetSiblingIndex(2);
    }
    private void ShuffleRight()
    {
        speechBubbles = FindObjectsOfType<SpeechBubble>().OrderBy(m => m.transform.position.x).ToArray();
        speechBubbles[0].GetComponent<Animator>().SetTrigger("BottomToMid");
        speechBubbles[1].GetComponent<Animator>().SetTrigger("MidToTop");
        speechBubbles[2].GetComponent<Animator>().SetTrigger("TopToBottom");
        speechBubbles[1].transform.SetSiblingIndex(2);
        speechBubbles[0].transform.SetSiblingIndex(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
