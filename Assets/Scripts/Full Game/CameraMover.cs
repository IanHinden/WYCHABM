using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private float[][] coordinates = new float[][] {
        new float[2] {0f, 0f},
        new float[2] { 61.1f, 0f}
    };

    private int currentCoordinates = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCamera()
    {
        currentCoordinates++;
        Camera.current.transform.Translate(coordinates[currentCoordinates][0], coordinates[currentCoordinates][1], 0);

    }
}
