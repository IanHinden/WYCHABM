using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheekToCheekSFXController : MonoBehaviour
{
    [SerializeField] GameObject Kiss;
    [SerializeField] GameObject LonelyWind;
    [SerializeField] GameObject Hit;

    private AudioSource KissAS;
    private AudioSource LonelyWindAS;
    private AudioSource HitAS;
    void Awake()
    {
        KissAS = Kiss.GetComponent<AudioSource>();
        LonelyWindAS = LonelyWind.GetComponent<AudioSource>();
        HitAS = Hit.GetComponent<AudioSource>();
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
}
