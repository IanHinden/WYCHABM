using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredTears : MonoBehaviour
{
    SpriteRenderer tears;
    void Awake()
    {
        tears = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        tears.color = new Color(1f, 1f, 1f, Random.Range(.7f, 1f));
    }
}
