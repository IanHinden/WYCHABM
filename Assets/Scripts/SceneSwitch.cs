﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] bool noTimer;
    [SerializeField] float measures;
    [SerializeField] bool gameScene;
    [SerializeField] bool measureSwitch;
    [SerializeField] bool lastScene;

    public AudioClip newTrack;

    private MusicPlayer theMP;

    ThreeSecondsLeft threeSecondsLeft;

    private void Awake()
    {
        theMP = FindObjectOfType<MusicPlayer>();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        StartCoroutine(WaitAndSwitch());
    }
    public void PlayGame()
    {
        LoadNextScene();
        //theMP.ChangeBGM(newTrack);
    }

    IEnumerator WaitAndSwitch()
    {
        if(noTimer) { yield break; }
        float timeToSwitch;
        float timeToEnd;

        if (!gameScene)
        {
            float measureSwitchTime = ReturnTimeOfScene();
            yield return new WaitForSeconds(measureSwitchTime - 1);
            yield return new WaitForSeconds(1);
            LoadNextScene();
        } else
        {
            threeSecondsLeft.showSlider();
            timeToEnd = threeSecondsLeft.ReturnTimeToEnd();
            float singleMeasure = threeSecondsLeft.ReturnSingleMeasure();
            timeToSwitch = (singleMeasure * measures) - timeToEnd;

            yield return new WaitForSeconds(timeToSwitch);

            threeSecondsLeft.StartCountdown();
            yield return new WaitForSeconds(timeToEnd);

            threeSecondsLeft.hideSlider();
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        if (lastScene == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            if (threeSecondsLeft.ReturnScore() > 4)
            {
                SceneManager.LoadScene(39);
            } else
            {
                SceneManager.LoadScene(39);
            }
        }
    }

    public float ReturnMeasures()
    {
        return measures;
    }

    public float ReturnTimeOfScene()
    {
        return measures * threeSecondsLeft.ReturnSingleMeasure();
    }
}