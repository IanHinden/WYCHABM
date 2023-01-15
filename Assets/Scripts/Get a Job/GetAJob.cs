using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAJob : MonoBehaviour
{
    [SerializeField] Camera cam;

    Animator CamAnim;
    void Awake()
    {
        cam.GetComponent<Camera>().orthographicSize = 3;
        CamAnim = cam.GetComponent<Animator>();
        CamAnim.SetTrigger("GetAJob");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
