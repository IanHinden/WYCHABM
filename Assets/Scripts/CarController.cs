using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Vector3 change;
    public float speed;
    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change.x = Input.GetAxisRaw("Horizontal");
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}
