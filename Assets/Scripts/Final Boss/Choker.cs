using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choker : MonoBehaviour
{
    SpriteRenderer chokerSR;
    // Start is called before the first frame update
    void Awake()
    {
        chokerSR = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Invisible()
    {
        chokerSR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
