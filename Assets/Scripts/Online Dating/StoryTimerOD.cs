using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTimerOD : MonoBehaviour
{
    private ThreeSecondsLeft threeSecondsLeft;

    private SpriteRenderer flashing;
    // Start is called before the first frame update
    void Awake()
    {
        threeSecondsLeft = gameObject.AddComponent<ThreeSecondsLeft>();

        flashing = FindObjectOfType<Topless>().GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
