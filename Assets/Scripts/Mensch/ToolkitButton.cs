using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolkitButton : MonoBehaviour
{
    public bool colliding;
    SpriteRenderer sr;
    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        colliding = true;
        if (col.gameObject.name == "Tapping")
        {
            sr.color = new Color(0.358f, 0.358f, 0.358f, 0.169f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        colliding = false;
        if (col.gameObject.name == "Tapping")
        {
            sr.color = new Color(0.358f, 0.358f, 0.358f, 0f);
        }
    }

    public bool ButtonPress()
    {
        if(colliding == true)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
