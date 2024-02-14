using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixSFXController : MonoBehaviour
{
    [SerializeField] GameObject StirringIceSFX;
    [SerializeField] GameObject HeavenlyChorusSFX;
    [SerializeField] GameObject BirdsSFX;

    private AudioSource StirringIceSFFXAS;
    private AudioSource HeavenlyChorusSFXAS;
    private AudioSource BirdsSFXAS;

    void Awake()
    {
        StirringIceSFFXAS = StirringIceSFX.GetComponent<AudioSource>();
        HeavenlyChorusSFXAS = HeavenlyChorusSFX.GetComponent<AudioSource>();
        BirdsSFXAS = BirdsSFX.GetComponent<AudioSource>();
    }

    public void PlayStirringIce()
    {
        StirringIceSFFXAS.time = 1;
        StirringIceSFFXAS.Play();
    }

    public void PauseStirringIce()
    {
        StirringIceSFFXAS.Pause();
    }

    public void PlayHeavenlyChorus()
    {
        HeavenlyChorusSFXAS.Play();
    }

    public void PlayBirds()
    {
        BirdsSFXAS.Play();
    }
}
