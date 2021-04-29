using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer girl = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        girl.color = new Color32(126, 126, 126, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
