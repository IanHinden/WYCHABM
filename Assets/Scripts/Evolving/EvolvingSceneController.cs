using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EvolvingSceneController : MonoBehaviour
{
    [SerializeField] ScoreHandler scorehandler;
    //[SerializeField] EvolvingText evolvingText;
    [SerializeField] GameObject evolvingText;

    private TextMeshPro textmesh;

    GameControls gamecontrols;

    //Animator starAnim;

    public GameObject BadBoy;
    public GameObject BadMan;
    public GameObject Mixed;

    SpriteRenderer badBoySR;
    SpriteRenderer badManSR;
    SpriteRenderer mixedSR;

    private IEnumerator blinking;
    private IEnumerator evolving;
    
    void Awake()
    {
        gamecontrols = new GameControls();
        badBoySR = BadBoy.GetComponent<SpriteRenderer>();
        badManSR = BadMan.GetComponent<SpriteRenderer>();
        mixedSR = Mixed.GetComponent<SpriteRenderer>();

        //starAnim = threeSecondsLeft.transform.Find("CountdownImages").transform.GetChild(3).transform.GetChild(5).GetComponent<Animator>();

        textmesh = evolvingText.GetComponent<TextMeshPro>();

        gamecontrols.Move.Stop.performed += x => StopEvolution();
        setIntroText();
        blinking = Blinking();
        evolving = setEvolvedText();

        StartCoroutine(blinking);
    }

    private void StopEvolution()
    {
        StopCoroutine(blinking);
        StopCoroutine(evolving);
        displayBadBoy();
        scorehandler.IncrementBonusScore();
        StartCoroutine(setArrestedText());
        gamecontrols.Disable();
    }

    private IEnumerator Blinking()
    {
        //.4 * 4
        displayBadBoy();
        yield return new WaitForSeconds(.6f);
        displayBadMan();
        yield return new WaitForSeconds(.04f);
        displayMixed();
        yield return new WaitForSeconds(.04f);
        displayBadBoy();
        yield return new WaitForSeconds(.1f);
        displayBadMan();
        yield return new WaitForSeconds(.1f);
        displayMixed();
        yield return new WaitForSeconds(.04f);
        displayBadBoy();
        yield return new WaitForSeconds(.1f);
        displayBadMan();
        yield return new WaitForSeconds(.08f);
        displayMixed();
        yield return new WaitForSeconds(.08f);
        displayBadBoy();
        yield return new WaitForSeconds(.05f);
        displayBadMan();
        yield return new WaitForSeconds(.05f);
        displayMixed();
        yield return new WaitForSeconds(.08f);
        displayBadBoy();
        yield return new WaitForSeconds(.05f);
        displayBadMan();
        yield return new WaitForSeconds(.08f);
        displayMixed();
        yield return new WaitForSeconds(.08f);
        displayBadBoy();
        yield return new WaitForSeconds(.05f);
        displayBadMan();
        yield return new WaitForSeconds(.05f);
        displayMixed();
        yield return new WaitForSeconds(.08f);
        displayBadBoy();
        yield return new WaitForSeconds(.05f);
        displayBadMan();

        yield return new WaitForSeconds(1f);
        StartCoroutine(evolving);
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    private void displayBadBoy()
    {
        if(badBoySR != null) badBoySR.enabled = true;
        if(badManSR != null) badManSR.enabled = false;
        if(mixedSR != null) mixedSR.enabled = false;
    }

    private void displayBadMan()
    {
        badBoySR.enabled = false;
        badManSR.enabled = true;
        mixedSR.enabled = false;
    }

    private void displayMixed()
    {
        badBoySR.enabled = false;
        badManSR.enabled = false;
        mixedSR.enabled = true;
    }

    private void setIntroText()
    {
        if(textmesh != null) textmesh.text = "What?                BAD BOY is evolving.";
    }

    private IEnumerator setEvolvedText()
    {
        textmesh.text = "";
        string evolvetext = "BAD BOY evolved into BAD MAN!";
        foreach (char c in evolvetext.ToCharArray())
        {
            textmesh.text += c;
            float pauseTime = .02f;

            while (pauseTime > 0)
            {
                pauseTime -= Time.deltaTime;
                yield return null;
            }
        }
    }

    private IEnumerator setArrestedText()
    {
        textmesh.text = "";
        string evolvetext = "Huh? BAD BOY stopped evolving! Arrested development.";
        foreach (char c in evolvetext.ToCharArray())
        {
            textmesh.text += c;
            float pauseTime = .02f;

            while (pauseTime > 0)
            {
                pauseTime -= Time.deltaTime;
                yield return null;
            }
        }
    }

    public void Reset()
    {
        displayBadBoy();
        setIntroText();
    }
}
