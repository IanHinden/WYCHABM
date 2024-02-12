using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancySFXController : MonoBehaviour
{
    [SerializeField] GameObject IncrementSFX;

    private AudioSource IncremenetSFXAS;

    void Awake()
    {
        IncremenetSFXAS = IncrementSFX.GetComponent<AudioSource>();
    }

    public void PlayIncrement(float pitch)
    {
        IncremenetSFXAS.pitch = pitch;
        IncremenetSFXAS.Play();
    }
}
