using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
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
            if (change.x == -1)
            {
                myRigidBody.rotation += speed * Time.deltaTime;
            }
            else if (change.x == 1)
            {
                myRigidBody.rotation -= speed * Time.deltaTime;
            }
        }
    }
}
