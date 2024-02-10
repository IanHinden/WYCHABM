using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsSlap : MonoBehaviour
{
    [SerializeField] CheekToCheekSFXController cheekToCheekSFXController;

    private void SlapSFX()
    {
        cheekToCheekSFXController.PlayHit();
    }
}
