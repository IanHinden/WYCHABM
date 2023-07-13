using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private GameControls gamecontrols;
    private new Print print;
    private bool moved = false;

    private float speed = 5f;
    
    private void Awake()
    {
        gamecontrols = new GameControls();
        print = FindObjectOfType<Print>();
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    public bool getMoved()
    {
        return moved;
    }

    public void resetMoved()
    {
        moved = false;
    }

    void Update()
    {
        Vector2 movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        if (movementInput.x != 0 || movementInput.y != 0)
        {
            moved = true;
        }

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;
        currentPosition.x = Mathf.Clamp(currentPosition.x, 2f, 3.5f);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -1.8f, -1.2f);

        print.InkSpawner();

        transform.position = currentPosition;
    }
}
