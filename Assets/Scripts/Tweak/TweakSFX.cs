using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweakSFX : MonoBehaviour
{
    [SerializeField] GameObject BlinkSFX;
    [SerializeField] GameObject BalloonSFX;

    private AudioSource BlinkSFXAS;
    private AudioSource BalloonSFXAS;
    
    void Awake()
    {
        BlinkSFXAS = BlinkSFX.GetComponent<AudioSource>();
        BalloonSFXAS = BalloonSFX.GetComponent<AudioSource>();
    }

    public void PlayBlink()
    {
        BlinkSFXAS.Play();
    }

    public void PlayBalloon()
    {
        BalloonSFXAS.Play();
    }
}
