using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpankArm : MonoBehaviour
{
    private bool spank = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spank()
    {
        if (spank == true)
        {
            transform.Rotate(0, 0, Time.deltaTime * 250, Space.Self);
        }
    }

    public void StartSpank()
    {
        spank = true;
    }
}
