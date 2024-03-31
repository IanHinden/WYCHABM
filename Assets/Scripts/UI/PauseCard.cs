using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCard : MonoBehaviour
{
    [SerializeField] MenuSFX menuSFX;

    private void playFlip()
    {
        menuSFX.PlayFlip();
    }
}
