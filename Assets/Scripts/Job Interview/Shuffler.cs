using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shuffler : MonoBehaviour
{
    private SpeechBubble[] speechBubbles;

    private SwitchCards switchCards;

    ThreeSecondsLeft threeSecondsLeft;

    private float timeToPress = 0f;
    private int selected = 2;

    void Awake()
    {
        switchCards = new SwitchCards();

        switchCards.Selecting.LeftSelect.performed += x => ShuffleLeft();
        switchCards.Selecting.RightSelect.performed += x => ShuffleRight();
        switchCards.Selecting.Select.performed += x => Select();

        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
    }

    private void OnEnable()
    {
        switchCards.Enable();
    }

    private void OnDisable()
    {
        switchCards.Disable();
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

    private void Select()
    {
        switchCards.Disable();
        if(selected == 0)
        {
            threeSecondsLeft.DisplayScoreCard();
            threeSecondsLeft.WinDisplay();
        } else
        {
            threeSecondsLeft.LoseDisplay();
        }
    }
}
