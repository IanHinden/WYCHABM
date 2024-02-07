using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    [SerializeField] GameObject PauseSFX;

    private AudioSource PauseSFXAS;
    void Awake()
    {
        PauseSFXAS = PauseSFX.GetComponent<AudioSource>();
    }

    public void PlayPause()
    {
        PauseSFXAS.Play();
    }
}
