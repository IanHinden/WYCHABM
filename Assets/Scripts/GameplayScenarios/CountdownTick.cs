using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTick : MonoBehaviour
{
    private AudioSource countdownTick;
    void Awake()
    {
        countdownTick = this.GetComponent<AudioSource>();
    }

    public void playTick()
    {
        countdownTick.Play();
    }
}
