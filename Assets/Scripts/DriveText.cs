using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveText : MonoBehaviour
{
    public float timeSinceStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart > 5)
        {
            ToggleVisibility();
        }
    }

    public void ToggleVisibility()
    {
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        rend.enabled = false;
    }
}
