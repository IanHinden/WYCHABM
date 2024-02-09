using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixSFXController : MonoBehaviour
{
    [SerializeField] GameObject StirringIceSFX;

    private AudioSource StirringIceSFFXAS;
    void Awake()
    {
        StirringIceSFFXAS = StirringIceSFX.GetComponent<AudioSource>();
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
}
