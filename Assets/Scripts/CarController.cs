using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Vector3 change;
    public float speed;
    private Rigidbody2D myRigidBody;
    public float timeSinceStart;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;

        change.x = Input.GetAxisRaw("Horizontal");
        if (timeSinceStart > 5)
        {
            myRigidBody.MovePosition(
                transform.position + change * speed * Time.deltaTime
            );
        }
    }
}
