using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolkitButton : MonoBehaviour
{
    public static event Action Win = delegate { };

    private void OnTriggerEnter2D()
    {
        Win();
    }
}
