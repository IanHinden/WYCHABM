using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychoSFXController : MonoBehaviour
{
    [SerializeField] GameObject TornPaperSFX;
    [SerializeField] GameObject OedipalBonusSFX;
    [SerializeField] GameObject FreudSFX;

    private AudioSource TornPaperSFXAS;
    private AudioSource OedipalBonusSFXAS;
    private AudioSource FreudSFXAS;
    
    void Awake()
    {
        TornPaperSFXAS = TornPaperSFX.GetComponent<AudioSource>();
        OedipalBonusSFXAS = OedipalBonusSFX.GetComponent<AudioSource>();
        FreudSFXAS = FreudSFX.GetComponent<AudioSource>();
    }

    public void PlayTornPaper()
    {
        TornPaperSFXAS.Play();
    }

    public void PlayOediplayBonus()
    {
        OedipalBonusSFXAS.Play();
    }

    public void PlayFreud()
    {
        FreudSFXAS.Play();
    }
}
