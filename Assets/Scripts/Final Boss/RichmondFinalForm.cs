using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichmondFinalForm : MonoBehaviour
{
    SpriteRenderer richmondSR;
    // Start is called before the first frame update
    void Awake()
    {
        richmondSR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Visible()
    {
        richmondSR.enabled = true;
    }
}
