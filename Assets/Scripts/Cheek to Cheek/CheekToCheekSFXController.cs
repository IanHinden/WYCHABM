using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheekToCheekSFXController : MonoBehaviour
{
    [SerializeField] GameObject Kiss;
    [SerializeField] GameObject LonelyWind;
    [SerializeField] GameObject Hit;
    [SerializeField] GameObject Miss;

    private AudioSource KissAS;
    private AudioSource LonelyWindAS;
    private AudioSource HitAS;
    private AudioSource MissAS;
    void Awake()
    {
        KissAS = Kiss.GetComponent<AudioSource>();
        LonelyWindAS = LonelyWind.GetComponent<AudioSource>();
        HitAS = Hit.GetComponent<AudioSource>();
        MissAS = Miss.GetComponent<AudioSource>();
    }

    public void PlayKiss()
    {
        KissAS.Play();
    }

    public IEnumerator PlayLonelyWind()
    {
        LonelyWindAS.time = 2;
        LonelyWindAS.Play();
        yield return new WaitForSeconds(1f);
        LonelyWindAS.Stop();
    }

    public void PlayHit()
    {
        HitAS.Play();
    }

    public void PlayMiss()
    {
        MissAS.Play();
    }
}
