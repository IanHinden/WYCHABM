using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsGameplay : MonoBehaviour
{
    Remove remove;

    void Awake()
    {
        remove = new Remove();
        remove.Tap.Up.performed += x => RemoveRing(); 
    }

    private void OnEnable()
    {
        remove.Enable();
    }

    private void OnDisable()
    {
        remove.Disable();
    }

    private void RemoveRing()
    {
        Debug.Log("Hey");
    }
}
