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
    [SerializeField] GameObject themeSong;

    [SerializeField] TimeKeeper timeKeeper;

    AudioSource audioSo;
    AudioSource guitarChordAS;
    AudioSource themeSongAS;

    private Coroutine gameCoroutine = null;

    private void Awake()
    {
        audioSo = mp.GetComponent<AudioSource>();
        guitarChordAS = guitarChord.GetComponent<AudioSource>();
        themeSongAS = themeSong.GetComponent<AudioSource>();
        themeSongAS.time = 5.5f;
        //themeSongAS.Play();
        StartCoroutine(FadeInMusic());
    }

    private IEnumerator FadeInMusic()
    {
        themeSongAS.volume = 0;
        float currentTime = 0;
        while(currentTime < .3f)
        {
            currentTime += Time.deltaTime;
            themeSongAS.volume = Mathf.Lerp(0, 1f, currentTime / .3f);
            yield return null;
        }
    }

    public void BeginGame()
    {
        themeSongAS.Stop();
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
