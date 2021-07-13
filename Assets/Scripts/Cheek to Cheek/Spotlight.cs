using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    private float RotateSpeed = 6f;
    private float Radius = 2f;
    private bool keepRotating;

    private Vector2 _centre;
    private float _angle;
    void Start()
    {
        _centre = new Vector3(4.6f, 2.2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotateSpotlight()
    {
        if (keepRotating == true) {
            _angle += RotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre + offset;
        }
    }

    public void StopRotating()
    {
        keepRotating = false;
    }
}
