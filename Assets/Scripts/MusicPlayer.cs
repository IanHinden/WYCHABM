using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    public float fadeDuration = .5f;
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

    public IEnumerator FadeOutMusic()
    {
        float startTime = Time.time;
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            float timeElapsed = Time.time - startTime;
            float volume = Mathf.Lerp(startVolume, 0, timeElapsed / fadeDuration);
            audioSource.volume = volume;

            yield return null;
        }

        audioSource.Stop();
    }
}
