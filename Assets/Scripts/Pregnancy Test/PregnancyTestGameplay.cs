using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyTestGameplay : MonoBehaviour
{
    private GameControls gamecontrols;

    [SerializeField] GameObject strawberry;

    public float rotationSpeed = 50f;
    public float rotationRange = 90f;
    void Awake()
    {
        gamecontrols = new GameControls();
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    public void OnDisable()
    {
        gamecontrols.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        float desiredRotation = strawberry.transform.rotation.eulerAngles.z + movementInput.x * rotationSpeed * Time.deltaTime;

        strawberry.transform.rotation = Quaternion.Euler(0f, 0f, desiredRotation);
    }
}
