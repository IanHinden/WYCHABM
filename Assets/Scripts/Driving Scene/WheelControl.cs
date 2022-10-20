using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    public float speed;
    public float timeSinceStart;

    private Rigidbody2D myRigidBody;
    private GameControls gamecontrols;


    // Start is called before the first frame update
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
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
        timeSinceStart += Time.deltaTime;
        Vector2 selectInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        if (timeSinceStart > 5)
        {
            if (selectInput.x == -1)
            {
                myRigidBody.rotation += speed * Time.deltaTime;
            }
            else if (selectInput.x == 1)
            {
                myRigidBody.rotation -= speed * Time.deltaTime;
            }
        }
    }
}
