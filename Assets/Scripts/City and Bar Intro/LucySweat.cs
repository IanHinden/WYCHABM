using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucySweat : MonoBehaviour
{
    [SerializeField] CityAndBarSFX cityAndBarSFX;

    private void PlaySweat()
    {
        cityAndBarSFX.LucySweat();
    }
}
