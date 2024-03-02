using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandlordSFXController : MonoBehaviour
{
    [SerializeField] GameObject ThunderSFX;

    private AudioSource ThunderSFXAS;
    void Awake()
    {
        ThunderSFXAS = ThunderSFX.GetComponent<AudioSource>();
    }

    public void PlayThunder()
    {
        ThunderSFXAS.Play();
    }
}
