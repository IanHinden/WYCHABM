using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreudStickHolder : MonoBehaviour
{
    [SerializeField] PsychoSFXController psychoSFXController;

    private void PlayFreud()
    {
        psychoSFXController.PlayFreud();
    }
}
