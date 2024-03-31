using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    [SerializeField] GameObject PauseSFX;
    [SerializeField] GameObject CardFlipSFX;

    private AudioSource PauseSFXAS;
    private AudioSource CardFlipSFXAS;
    void Awake()
    {
        PauseSFXAS = PauseSFX.GetComponent<AudioSource>();
        CardFlipSFXAS = CardFlipSFX.GetComponent<AudioSource>();
    }

    public void PlayPause()
    {
        PauseSFXAS.Play();
    }

    public void PlayFlip()
    {
        CardFlipSFXAS.Play();
    }
}
