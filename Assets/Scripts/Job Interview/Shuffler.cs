using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shuffler : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] CameraLogic cameraLogic;

    private SpeechBubble[] speechBubbles;

    private GameControls gamecontrols;

    private bool pressed = false;
    private float timeToPress = 0f;
    private int selected = 2;

    void Awake()
    {
        gamecontrols = new GameControls();

        gamecontrols.Select.LeftSelect.performed += x => ShuffleLeft();
        gamecontrols.Select.RightSelect.performed += x => ShuffleRight();
        gamecontrols.Select.Choose.performed += x => Select();

        //StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    private void ShuffleLeft()
    {
        if (timeToPress <= 0)
        {
            if (selected != 0)
            {
                selected--;
            }
            else
            {
                selected = 2;
            }

            speechBubbles = FindObjectsOfType<SpeechBubble>().OrderBy(m => m.transform.position.x).ToArray();
            speechBubbles[0].GetComponent<Animator>().SetTrigger("BottomToTop");
            speechBubbles[1].GetComponent<Animator>().SetTrigger("MidToBottom");
            speechBubbles[2].GetComponent<Animator>().SetTrigger("TopToMid");
            speechBubbles[0].transform.SetSiblingIndex(2);
            StartCoroutine(CountdownTimeToPress());
        }
    }
    private void ShuffleRight()
    {
        if (timeToPress <= 0)
        {
            if(selected != 2)
            {
                selected++;
            } else
            {
                selected = 0;
            }

            speechBubbles = FindObjectsOfType<SpeechBubble>().OrderBy(m => m.transform.position.x).ToArray();
            speechBubbles[0].GetComponent<Animator>().SetTrigger("BottomToMid");
            speechBubbles[1].GetComponent<Animator>().SetTrigger("MidToTop");
            speechBubbles[2].GetComponent<Animator>().SetTrigger("TopToBottom");
            speechBubbles[1].transform.SetSiblingIndex(2);
            speechBubbles[0].transform.SetSiblingIndex(1);
            StartCoroutine(CountdownTimeToPress());
        }
    }

    IEnumerator CountdownTimeToPress()
    {
        timeToPress = .3f;
        yield return new WaitForSeconds(timeToPress);
        timeToPress = 0f;
    }

    public IEnumerator WinOrLose()
    {
        StartCoroutine(cameraLogic.moveToX(new Vector3(5.9f, 10.59f, -10), .5f));
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(5));
        selected = 1;
        if (pressed == false)
        {
            uihandler.LoseDisplay();
        }
    }

    private void Select()
    {
        pressed = true;
        gamecontrols.Disable();
        if(selected == 0)
        {
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
        } else
        {
            uihandler.LoseDisplay();
        }
    }

    public void Reset()
    {
        pressed = false;
        timeToPress = 0f;
        // Fill in with logic to reset selection
    }
}
