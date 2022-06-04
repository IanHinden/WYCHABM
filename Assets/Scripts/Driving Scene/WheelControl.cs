using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    private Vector3 change;
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
    void Update()
    {
        timeSinceStart += Time.deltaTime;
        float selectInput = driving.Drive.Steer.ReadValue<float>();

        if (timeSinceStart > 5)
        {
            if (selectInput == -1)
            {
                myRigidBody.rotation += speed * Time.deltaTime;
            }
            else if (selectInput == 1)
            {
                myRigidBody.rotation -= speed * Time.deltaTime;
            }
        }
    }
}
