using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingSceneSFXController : MonoBehaviour
{
    [SerializeField] GameObject PlayerCarSFX;
    [SerializeField] GameObject CarCrashSFX;

    private AudioSource PlayerCarSFXAS;
    private AudioSource CarCrashSFXAS;

    void Awake()
    {
        PlayerCarSFXAS = PlayerCarSFX.GetComponent<AudioSource>();
        CarCrashSFXAS = CarCrashSFX.GetComponent<AudioSource>();
    }

    public void PlayPlayerCarSound()
    {
        PlayerCarSFXAS.Play();
    }

    public void StopPlayerCarSound()
    {
        PlayerCarSFXAS.Stop();
    }

    public void PlayCarCrash()
    {
        CarCrashSFXAS.Play();
    }
}
