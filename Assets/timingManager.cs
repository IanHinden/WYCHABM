using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timingManager : MonoBehaviour
{
    public TextMeshPro dialogueBox;
    private Animation myTimer;
    private float wordSpeed = 0.01f;

    public rhythmGameSetUp[] rhythmGames;
    private int chorusCount = 0;

    void Awake()
    {
        myTimer = this.GetComponent<Animation>();
    }

    public void startTimer()
    {
        myTimer.Play();
    }

    public void stopTimer()
    {
        myTimer.Stop();
    }

    public void refreshDialogue()
    {
        dialogueBox.text = "";
    }

    public void adjustSpokenWordSpeed(float speedVariable)
    {
        wordSpeed = speedVariable;
    }

    public void newLyric(string spokenWord)
    {
        StartCoroutine(SetDialogue(spokenWord));
    }

    public void addSpace()
    {
        dialogueBox.text += " ";
    }

    public IEnumerator SetDialogue(string dialogue)
    {
        foreach (char c in dialogue.ToCharArray())
        {
            dialogueBox.text += c;
            float pauseTime = wordSpeed;

            while (pauseTime > 0)
            {
                pauseTime -= Time.deltaTime;
                yield return null;
            }
        }
    }

    //Rhythm Game Stuff

    public void increaseChorusCount()
    {
        chorusCount++;
    }

    public void addExampleArrow(string direction)
    {
        rhythmGames[chorusCount].addExampleArrow(direction);
    }

    public void addArrow(string direction)
    {
        rhythmGames[chorusCount].addArrow(direction);
    }
}
