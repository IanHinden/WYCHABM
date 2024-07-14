using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityAndBarSFX : MonoBehaviour
{
    [SerializeField] AudioSource avaSighSFXAS;
    [SerializeField] AudioSource lucyEnterSFXAS;
    [SerializeField] AudioSource avaBlinkSFXAS;
    [SerializeField] AudioSource avaProudSFXAS;
    [SerializeField] AudioSource lucySweatSFXAS;

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
