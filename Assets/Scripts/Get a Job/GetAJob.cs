using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAJob : MonoBehaviour
{
    [SerializeField] Camera cam;

    Animator CamAnim;
    void Awake()
    {
        CamAnim = cam.GetComponent<Animator>();
        CamAnim.SetTrigger("GetAJob");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
