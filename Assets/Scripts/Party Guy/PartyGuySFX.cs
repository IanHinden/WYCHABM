using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyGuySFX : MonoBehaviour
{
    [SerializeField] GameObject TextBubble;

    private AudioSource TextBubbleAS;
    void Awake()
    {
        TextBubbleAS = TextBubble.GetComponent<AudioSource>();
    }

    public void PlayTextBubble()
    {
        TextBubbleAS.Play();
    }
}
