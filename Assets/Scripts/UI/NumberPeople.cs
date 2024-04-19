using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPeople : MonoBehaviour
{
    [SerializeField] AudioSource bonusSound;

    private void PlayBonusSound()
    {
        bonusSound.Play();
    }
}
