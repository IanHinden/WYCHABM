using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetect : MonoBehaviour
{
    private BoxCollider2D collider;

    private void Awake()
    {
        // Cache the BoxCollider2D component
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Check for mouse button clicks
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Get the mouse position in world space
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // Check if the mouse position is within the clickable area's Collider bounds
            if (collider.bounds.Contains(mousePosition))
            {
                // This code will be executed when the invisible area is clicked.
                Debug.Log("Invisible area clicked!");

                // You can add any logic here that you want to perform when the area is clicked.
            }
        }
    }
}
