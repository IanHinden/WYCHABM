using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectSFXController : MonoBehaviour
{
    [SerializeField] AudioSource highlightSFX;

    public void playHighlightSFX()
    {
        highlightSFX.Play();
    }
}
