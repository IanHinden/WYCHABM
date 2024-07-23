using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCone : MonoBehaviour
{
    [SerializeField] DrivingSceneSFXController drivingSceneSFXController;
    [SerializeField] ConeSpawner coneSpawner;

    private bool played = false;

    public void ConeBehavior()
    {
        if (played == false)
        {
            played = true;
            drivingSceneSFXController.PlayTrafficCone();
            coneSpawner.SpawnCone();
        }
    }

    public void ResetCone()
    {
        played = false;
    }
}
