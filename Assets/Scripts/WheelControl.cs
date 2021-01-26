using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
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
        Debug.Log(change.x);
        if (change.x == -1)
        {
            myRigidBody.rotation += speed * Time.deltaTime;
            Debug.Log(myRigidBody.rotation);
        } else if (change.x == 1)
        {
            myRigidBody.rotation -= speed * Time.deltaTime;
        }
    }
}
