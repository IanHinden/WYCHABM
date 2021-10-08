using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyDriver : MonoBehaviour
{
    public static event Action<int> TestThing = delegate { };

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D()
    {
        TestThing(4);
    }
}
