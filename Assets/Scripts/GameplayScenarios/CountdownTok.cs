using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTok : MonoBehaviour
{
    private AudioSource countdownTok;
    void Awake()
    {
        countdownTok = this.GetComponent<AudioSource>();
    }

    public void playTok()
    {
        countdownTok.Play();
    }
}
