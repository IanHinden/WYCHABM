using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionSFXController : MonoBehaviour
{
    [SerializeField] AudioSource CollectAS;
    [SerializeField] AudioSource SignAS;
    [SerializeField] AudioSource SelectAS;
    [SerializeField] AudioSource DontAS;
    [SerializeField] AudioSource StabAS;
    [SerializeField] AudioSource GetAJobAS;
    [SerializeField] AudioSource DriveAS;
    [SerializeField] AudioSource KissAS;
    [SerializeField] AudioSource HitAS;
    [SerializeField] AudioSource SpoilAS;
    [SerializeField] AudioSource TweakAS;
    [SerializeField] AudioSource ShareAS;
    [SerializeField] AudioSource MixAS;
    [SerializeField] AudioSource StealthAS;
    [SerializeField] AudioSource AimAS;
    public delegate void SoundFunction();
    private SoundFunction[] SoundFunctions = new SoundFunction[15];

    private void Awake()
    {
        SoundFunctions[0] = PlayCollect;
        SoundFunctions[1] = PlaySign;
        SoundFunctions[2] = PlaySelect;
        SoundFunctions[3] = PlayDont;
        SoundFunctions[4] = PlayStab;
        SoundFunctions[5] = PlayGetAJob;
        SoundFunctions[6] = PlayDrive;
        SoundFunctions[7] = PlayKiss;
        SoundFunctions[8] = PlayHit;
        SoundFunctions[9] = PlaySpoil;
        SoundFunctions[10] = PlayTweak;
        SoundFunctions[11] = PlayShare;
        SoundFunctions[12] = PlayMix;
        SoundFunctions[13] = PlayStealth;
        SoundFunctions[14] = PlayAim;
    }

    private void PlayCollect()
    {
        CollectAS.Play();
    }

    private void PlaySign()
    {
        SignAS.Play();
    }

    private void PlaySelect()
    {
        SelectAS.Play();
    }

    private void PlayDont()
    {
        DontAS.Play();
    }

    private void PlayStab()
    {
        StabAS.Play();
    }

    private void PlayGetAJob()
    {
        GetAJobAS.Play();
    }

    private void PlayDrive()
    {
        DriveAS.Play();
    }

    private void PlayKiss()
    {
        KissAS.Play();
    }

    private void PlayHit()
    {
        HitAS.Play();
    }

    private void PlaySpoil()
    {
        SpoilAS.Play();
    }

    private void PlayTweak()
    {
        TweakAS.Play();
    }

    private void PlayShare()
    {
        ShareAS.Play();
    }

    private void PlayMix()
    {
        MixAS.Play();
    }

    private void PlayStealth()
    {
        StealthAS.Play();
    }

    private void PlayAim()
    {
        AimAS.Play();
    }

    public void PlaySound(int index)
    {
        if (index >= 0 && index < SoundFunctions.Length)
        {
            SoundFunctions[index]();
        } else
        {
            Debug.LogError("Invalid sound index");
        }
    } 
}
