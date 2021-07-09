using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed;
    public float timeSinceStart;

    private Rigidbody2D myRigidBody;
    private Driving driving;


    // Start is called before the first frame update
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        driving = new Driving();
    }

    private void OnEnable()
    {
        driving.Enable();
    }

    private void OnDisable()
    {
        driving.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceStart += Time.deltaTime;
        float selectInput = driving.Drive.Steer.ReadValue<float>();
        float currentPosition = transform.position.x;

        if (timeSinceStart > 5)
        {
            currentPosition += selectInput * speed * Time.deltaTime;
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
        }
    }
}
