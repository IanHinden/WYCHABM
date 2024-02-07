using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschAudioController : MonoBehaviour
{
    [SerializeField] GameObject PunchSFX;

    private AudioSource PunchSFXAS;

    void Awake()
    {
        PunchSFXAS = PunchSFX.GetComponent<AudioSource>();
    }

    public void PlayPunch()
    {
        PunchSFXAS.Play();
    }
}
