using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychoSFXController : MonoBehaviour
{
    [SerializeField] AudioSource PunchAS;
    [SerializeField] AudioSource TornPaperSFXAS;
    [SerializeField] AudioSource OedipalBonusSFXAS;
    [SerializeField] AudioSource FreudSFXAS;
    [SerializeField] AudioSource PopAS;

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

    public void PlayPunch()
    {
        PunchAS.Play();
    }

    public void PlayPop()
    {
        PopAS.Play();
    }
}
