using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCone : MonoBehaviour
{
    [SerializeField] DrivingSceneSFXController drivingSceneSFXController;

    private bool played = false;

    public void ConeBehavior()
    {
        if (played == false)
        {
            played = true;
            drivingSceneSFXController.PlayTrafficCone();
        }
    }

    public void ResetCone()
    {
        played = false;
    }
}
