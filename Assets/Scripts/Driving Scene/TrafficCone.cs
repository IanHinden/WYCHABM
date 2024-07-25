using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCone : MonoBehaviour
{
    [SerializeField] DrivingSceneSFXController drivingSceneSFXController;
    [SerializeField] ConeSpawner coneSpawner;

    private SpriteRenderer coneSR;

    private bool played = false;

    private void Awake()
    {
        coneSR = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void ConeBehavior()
    {
        coneSR.enabled = false;
        if (played == false)
        {
            played = true;
            drivingSceneSFXController.PlayTrafficCone();
            coneSpawner.SpawnCone();
            Debug.Log(coneSR);
        }
    }

    public bool returnPlayed()
    {
        return played;
    }

    public void ResetCone()
    {
        played = false;
    }
}
