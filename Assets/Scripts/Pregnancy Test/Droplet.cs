using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 initialVelocity = new Vector3(1000f, 1000f, 0f);
    private void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Check if the object has a Rigidbody
        if (rb != null)
        {
            // Set the initial velocity
            rb.velocity = transform.up * speed;
        }
    }
}
