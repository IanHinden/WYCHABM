using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementSFXController : MonoBehaviour
{
    [SerializeField] GameObject Meow;
    [SerializeField] GameObject MeowTwo;

    private AudioSource MeowAS;
    private AudioSource MeowTwoAS;

    void Awake()
    {
        MeowAS = Meow.GetComponent<AudioSource>();
        MeowTwoAS = MeowTwo.GetComponent<AudioSource>();
    }

    public void PlayMeow()
    {
        MeowAS.Play();
    }

    public void PlayMeowTwo()
    {
        MeowTwoAS.Play();
    }
}
