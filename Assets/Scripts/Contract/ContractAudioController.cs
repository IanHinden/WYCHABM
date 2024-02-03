using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractAudioController : MonoBehaviour
{
    [SerializeField] GameObject penSound;
    [SerializeField] GameObject switchBeep;

    private AudioSource penSoundAS;
    private AudioSource switchBeepAS;
    void Awake()
    {
        penSoundAS = penSound.GetComponent<AudioSource>();
        switchBeepAS = switchBeep.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayPen()
    {
        penSoundAS.time = 1;
        penSoundAS.Play();
    }

    public void PausePen()
    {
        penSoundAS.Pause();
    }

    public void ResetPen()
    {
        penSoundAS.Stop();
        penSoundAS.time = 1;
    }

    public void PlaySwitch()
    {
        switchBeepAS.Play();
    }
}
