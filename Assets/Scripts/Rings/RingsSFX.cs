using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsSFX : MonoBehaviour
{
    [SerializeField] GameObject BalloonSFX;

    private AudioSource BalloonSFXAS;

    void Awake()
    {
        BalloonSFXAS = BalloonSFX.GetComponent<AudioSource>();
    }

    public void PlayBalloon(float pitch)
    {
        BalloonSFXAS.pitch = pitch;
        BalloonSFXAS.Play();
    }
}
