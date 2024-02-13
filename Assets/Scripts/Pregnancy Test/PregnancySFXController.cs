using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancySFXController : MonoBehaviour
{
    [SerializeField] GameObject IncrementSFX;
    [SerializeField] GameObject TinkSFX;
    [SerializeField] GameObject StreamSFX;
    [SerializeField] GameObject UnzipSFX;

    private AudioSource IncremenetSFXAS;
    private AudioSource TinkSFXAS;
    private AudioSource StreamSFXAS;
    private AudioSource UnzipSFXAS;

    void Awake()
    {
        IncremenetSFXAS = IncrementSFX.GetComponent<AudioSource>();
        TinkSFXAS = TinkSFX.GetComponent<AudioSource>();
        StreamSFXAS = StreamSFX.GetComponent<AudioSource>();
        UnzipSFXAS = UnzipSFX.GetComponent<AudioSource>();
    }

    public void PlayIncrement(float pitch)
    {
        IncremenetSFXAS.pitch = pitch;
        IncremenetSFXAS.Play();
    }

    public void PlayTink()
    {
        TinkSFXAS.Play();
    }

    public void PlayStream()
    {
        StreamSFXAS.Play();
    }

    public void StopStream()
    {
        StreamSFXAS.Stop();
    }

    public void PlayUnzip()
    {
        UnzipSFXAS.Play();
    }
}
