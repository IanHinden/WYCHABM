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
        Debug.Log("Yeah!");
        speechBubbles[1].GetComponent<Animator>().SetTrigger("MidToBottom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
