using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puff : MonoBehaviour
{
    [SerializeField] CityAndBarSFX cityAndBarSFX;

    private void PlaySigh()
    {
        cityAndBarSFX.AvaSigh();
    }
}
