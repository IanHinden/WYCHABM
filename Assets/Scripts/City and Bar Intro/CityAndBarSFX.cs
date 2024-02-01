using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityAndBarSFX : MonoBehaviour
{
    [SerializeField] GameObject avaSighSFX;
    [SerializeField] GameObject lucyEnterSFX;
    [SerializeField] GameObject avaBlinkSFX;
    [SerializeField] GameObject avaProudSFX;
    [SerializeField] GameObject lucySweatSFX;

    private AudioSource avaSighSFXAS;
    private AudioSource lucyEnterSFXAS;
    private AudioSource avaBlinkSFXAS;
    private AudioSource avaProudSFXAS;
    private AudioSource lucySweatSFXAS;
    void Awake()
    {
        avaSighSFXAS = avaSighSFX.GetComponent<AudioSource>();
        lucyEnterSFXAS = lucyEnterSFX.GetComponent<AudioSource>();
        avaBlinkSFXAS = avaBlinkSFX.GetComponent<AudioSource>();
        avaProudSFXAS = avaProudSFX.GetComponent<AudioSource>();
        lucySweatSFXAS = lucySweatSFX.GetComponent<AudioSource>();
    }

    public void AvaSigh()
    {
        avaSighSFXAS.Play();
    }

    public void LucyEnter()
    {
        lucyEnterSFXAS.Play();
    }

    public void AvaBlink()
    {
        avaBlinkSFXAS.Play();
    }

    public void AvaProud()
    {
        avaProudSFXAS.Play();
    }

    public void LucySweat()
    {
        lucySweatSFXAS.Play();
    }
}
