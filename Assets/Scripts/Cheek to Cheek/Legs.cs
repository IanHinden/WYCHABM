using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    private bool legsUp = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LegsUp()
    {
        if (legsUp == true)
        {
            transform.Rotate(0, 0, Time.deltaTime * 400, Space.Self);
        }
    }

    public void StartLegsUp()
    {
        legsUp = true;
    }
}
