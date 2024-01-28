using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractAudioController : MonoBehaviour
{
    private AudioSource penSound;
    void Awake()
    {
        penSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayPen()
    {
        penSound.Play();
    }

    public void PausePen()
    {
        penSound.Pause();
    }

    public void ResetPen()
    {
        penSound.Stop();
        penSound.time = 0;
    }
}
