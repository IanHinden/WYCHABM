using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffler : MonoBehaviour
{
    private SpeechBubble[] speechBubbles;
    // Start is called before the first frame update
    void Awake()
    {
        speechBubbles = FindObjectsOfType<SpeechBubble>();
        speechBubbles[1].transform.SetSiblingIndex(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
