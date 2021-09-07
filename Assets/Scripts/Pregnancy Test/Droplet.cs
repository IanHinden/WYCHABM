using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    public float speed = 5.0f;

    void Awake()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(this.transform.position.y < -6.5)
        {
            Destroy(this.gameObject);
        }
    }
}
