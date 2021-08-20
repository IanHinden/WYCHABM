using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolkitButton : MonoBehaviour
{
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
        sr.color = new Color(0.358f, 0.358f, 0.358f, 0.169f);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        sr.color = new Color(0.358f, 0.358f, 0.358f, 0f);
    }
}
