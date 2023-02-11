﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;

    [SerializeField] MusicPlayer mp;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject barIntro;

    [SerializeField] TimeKeeper timeKeeper;

    AudioSource audioSo;

    private void Awake()
    {
        audioSo = mp.GetComponent<AudioSource>();
    }

    public void BeginGame()
    {
        uihandler.HideStartButton();
        audioSo.Play();
        barIntro.SetActive(true);
        StartCoroutine(timeKeeper.SwitchScene());
        titleScreen.SetActive(false);
    }
}
