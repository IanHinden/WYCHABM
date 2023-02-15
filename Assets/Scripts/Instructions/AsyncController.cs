using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncController : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    //[SerializeField] private MusicPlayer mp;

    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject barIntro;
    [SerializeField] GameObject timeKeeper;

    AudioSource audioSo;

    public void Awake()
    {
        //audioSo = mp.GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        audioSo.Play();
        barIntro.SetActive(true);
        timeKeeper.SetActive(true);
        titleScreen.SetActive(false);
    }
}
