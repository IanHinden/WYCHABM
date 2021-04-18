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
        if (timeSinceStart > 3.5)
        {
            ToggleVisibility(true);
        }

        if (timeSinceStart > 4.5)
        {
            ToggleVisibility(false);
        }
    }

    public void ToggleVisibility(bool visible)
    {
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();

        rend.enabled = visible;
    }
}
