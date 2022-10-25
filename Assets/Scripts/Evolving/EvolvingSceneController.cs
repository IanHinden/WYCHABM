using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvingSceneController : MonoBehaviour
{
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] EvolvingText evolvingText;
    StopEvolving stopEvolving;

    //Animator starAnim;

    public GameObject BadBoy;
    SpriteRenderer badBoySR;

    private IEnumerator evolving;
    private IEnumerator stopped;
    private IEnumerator blinking;
    
    void Awake()
    {
        stopEvolving = new StopEvolving();
        badBoySR = BadBoy.GetComponent<SpriteRenderer>();

        //starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(5).GetComponent<Animator>();

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
        scorehandler.IncrementBonusScore();
        stopEvolving.Disable();
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
