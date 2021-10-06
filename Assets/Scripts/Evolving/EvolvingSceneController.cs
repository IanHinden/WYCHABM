using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvingSceneController : MonoBehaviour
{

    EvolvingText evolvingText;
    StopEvolving stopEvolving;

    public GameObject BadBoy;
    SpriteRenderer badBoySR;

    private IEnumerator evolving;
    private IEnumerator stopped;
    private IEnumerator blinking;
    
    void Awake()
    {
        evolvingText = FindObjectOfType<EvolvingText>();
        stopEvolving = new StopEvolving();
        badBoySR = BadBoy.GetComponent<SpriteRenderer>();

        stopEvolving.Stop.StopEvolve.performed += x => StopEvolution();
        evolving = evolvingText.SetEvolvingDialogue();
        stopped = evolvingText.SetStoppedDialogue();
        blinking = Blinking();

        StartCoroutine(evolving);
        StartCoroutine(blinking);
    }

    private void StopEvolution()
    {
        StopCoroutine(evolving);
        StopCoroutine(blinking);
        badBoySR.enabled = true;
        StartCoroutine(stopped);
    }

    private IEnumerator Blinking()
    {
        badBoySR.enabled = true;
        yield return new WaitForSeconds(.4f);
        badBoySR.enabled = false;
        yield return new WaitForSeconds(.4f);
        badBoySR.enabled = true;
        yield return new WaitForSeconds(.4f);
        badBoySR.enabled = false;
        yield return new WaitForSeconds(.4f);
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
