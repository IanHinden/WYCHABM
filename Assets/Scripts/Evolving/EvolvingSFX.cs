using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvingSFX : MonoBehaviour
{
    [SerializeField] GameObject youngPigSqueal;
    [SerializeField] GameObject adultPig;

    private AudioSource youngPigSquealAS;
    private AudioSource adultPigAS;
    
    void Awake()
    {
        youngPigSquealAS = youngPigSqueal.GetComponent<AudioSource>();
        adultPigAS = adultPig.GetComponent<AudioSource>();
    }

    public IEnumerator PlayYoungPigSquealing()
    {
        youngPigSquealAS.Play();
        yield return new WaitForSeconds(.5f);
        youngPigSquealAS.Play();
    }

    public void PlayAdultPigSqueal()
    {
        adultPigAS.Play();
    }
}
