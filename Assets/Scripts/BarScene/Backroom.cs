using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backroom : MonoBehaviour
{
    CameraMovement cameraMovement;
    // Start is called before the first frame update
    void Awake()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(cameraMovement.MoveToBackroom());
    }
}
