using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyTestGameplay : MonoBehaviour
{
    private PregnancyTestControls pregnancyTestControls;
    private PregnancyTest pregnancyTest;

    private float speed = 5f;
    void Awake()
    {
        pregnancyTest = FindObjectOfType<PregnancyTest>();
        pregnancyTestControls = new PregnancyTestControls();
    }

    private void OnEnable()
    {
        pregnancyTestControls.Enable();
    }

    private void OnDisable()
    {
        pregnancyTestControls.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementInput = pregnancyTestControls.Move.Moving.ReadValue<float>();

        Vector3 currentPosition = pregnancyTest.transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        pregnancyTest.transform.position = currentPosition;
    }
}
