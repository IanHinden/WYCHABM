using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishlistSFX : MonoBehaviour
{
    [SerializeField] GameObject highlightSFX;

    private AudioSource highlightSFXAS;

    void Awake()
    {
        highlightSFXAS = highlightSFX.GetComponent<AudioSource>();    
    }

    public void PlayHighlight()
    {
        highlightSFXAS.Play();
    }
}
