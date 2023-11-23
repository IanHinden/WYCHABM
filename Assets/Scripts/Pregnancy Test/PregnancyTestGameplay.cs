using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyTestGameplay : MonoBehaviour
{
    private GameControls gamecontrols;
    private PregnancyTest pregnancyTest;

    [SerializeField] GameObject strawberry;

    private float speed = 5f;
    public float rotationSpeed = 50f;
    public float rotationRange = 90f;
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
    void Update()
    {
        Vector2 movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        /*Vector3 currentPosition = pregnancyTest.transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        pregnancyTest.transform.position = currentPosition;*/

        float desiredRotation = strawberry.transform.rotation.eulerAngles.z + movementInput.x * rotationSpeed * Time.deltaTime;

        strawberry.transform.rotation = Quaternion.Euler(0f, 0f, desiredRotation);
    }
}
