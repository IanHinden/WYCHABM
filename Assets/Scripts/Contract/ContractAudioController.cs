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
        if (penSoundAS != null)
        {
            penSoundAS.time = 1;
            penSoundAS.Play();
        }
    }

    public void PausePen()
    {
        if (penSoundAS != null)
        {
            penSoundAS.Pause();
        }
    }

    public void ResetPen()
    {
        if (penSoundAS != null)
        {
            penSoundAS.Stop();
            penSoundAS.time = 1;
        }
    }

    public void PlaySwitch()
    {
        if (switchBeepAS != null)
        {
            switchBeepAS.Play();
        }
    }
}
