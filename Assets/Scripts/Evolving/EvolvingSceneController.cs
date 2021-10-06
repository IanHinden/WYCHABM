using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvingSceneController : MonoBehaviour
{

    EvolvingText evolvingText;
    StopEvolving stopEvolving;

    private IEnumerator evolving;
    private IEnumerator stopped;
    
    void Awake()
    {
        evolvingText = FindObjectOfType<EvolvingText>();
        stopEvolving = new StopEvolving();
        stopEvolving.Stop.StopEvolve.performed += x => StopEvolution();
        evolving = evolvingText.SetEvolvingDialogue();
        stopped = evolvingText.SetStoppedDialogue();
        StartCoroutine(evolving);
    }

    private void StopEvolution()
    {
        StopCoroutine(evolving);
        StartCoroutine(stopped);
    }

    private void OnEnable()
    {
        stopEvolving.Enable();
    }

    private void OnDisable()
    {
        stopEvolving.Disable();
    }
}
