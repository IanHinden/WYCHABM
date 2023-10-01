using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    public float fadeDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void ChangeBGM(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
    }

    public void FadeOutMusic()
    {
        audioSource.Stop();
    }
}
