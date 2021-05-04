using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private WritingControls writingControls;

    private float speed = 5f;
    
    private void Awake()
    {
        writingControls = new WritingControls();
    }

    private void OnEnable()
    {
        writingControls.Enable();
    }

    private void OnDisable()
    {
        writingControls.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementInput = writingControls.Move.Directions.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;
        currentPosition.x = Mathf.Clamp(currentPosition.x, 2f, 3.5f);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -1.8f, -1.2f);

        transform.position = currentPosition;
    }
}
