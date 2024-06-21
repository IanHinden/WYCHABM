using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichmanText : MonoBehaviour
{
    [SerializeField] AudioSource bubbleSFX;

    private void playBubbleSFX()
    {
        bubbleSFX.Play();
    }
}
