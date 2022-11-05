using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyTestGameplay : MonoBehaviour
{
    private GameControls gamecontrols;
    private PregnancyTest pregnancyTest;

    private float speed = 5f;
    void Awake()
    {
        pregnancyTest = FindObjectOfType<PregnancyTest>();
        gamecontrols = new GameControls();
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        Vector3 currentPosition = pregnancyTest.transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        pregnancyTest.transform.position = currentPosition;
    }
}
