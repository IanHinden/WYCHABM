using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowHolder : MonoBehaviour
{
    [SerializeField] JudgementSFXController judgementSFXController;

    public void PlayMeow()
    {
        judgementSFXController.PlayMeow();
    }

    public void PlayMeowTwo()
    {
        judgementSFXController.PlayMeowTwo();
    }
}
