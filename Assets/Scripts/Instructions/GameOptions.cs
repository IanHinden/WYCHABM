using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;

    [SerializeField] MusicPlayer mp;
    [SerializeField] GameObject guitarChord;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject barIntro;

    [SerializeField] TimeKeeper timeKeeper;

    AudioSource audioSo;
    AudioSource guitarChordAS;

    private Coroutine gameCoroutine = null;

    private void Awake()
    {
        audioSo = mp.GetComponent<AudioSource>();
        guitarChordAS = guitarChord.GetComponent<AudioSource>();
    }

    public void BeginGame()
    {
        uihandler.HideStartButton();
        uihandler.ShowPauseButton();
        guitarChordAS.Play();
        audioSo.Play();
        barIntro.SetActive(true);
        gameCoroutine = StartCoroutine(timeKeeper.SwitchScene());
        titleScreen.SetActive(false);
    }

    public void EndGame()
    {
        StopCoroutine(gameCoroutine);
    }
}
