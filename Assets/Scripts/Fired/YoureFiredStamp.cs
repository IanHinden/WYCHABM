using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoureFiredStamp : MonoBehaviour
{
    [SerializeField] GameObject StampSound;

    private AudioSource StampSoundAS;
    void Awake()
    {
        StampSoundAS = StampSound.GetComponent<AudioSource>();
    }

    private void PlayStamp()
    {
        StampSoundAS.Play();
    }
}
