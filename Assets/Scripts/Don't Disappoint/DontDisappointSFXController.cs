using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDisappointSFXController : MonoBehaviour
{
    [SerializeField] GameObject LoseSound;

    private AudioSource LoseSoundAS;

    void Awake()
    {
        LoseSoundAS = LoseSound.GetComponent<AudioSource>();    
    }

    public void PlayLoseSound()
    {
        LoseSoundAS.Play();
    }
}
