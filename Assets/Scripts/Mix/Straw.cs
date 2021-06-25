using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straw : MonoBehaviour
{
    private Stir stir;
    private float speed = 1.5f;
    private float moveAmount = 0f;
    private float currentPos;
    // Start is called before the first frame update
    void Awake()
    {
        stir = new Stir();
    }

    private void OnEnable()
    {
        stir.Enable();
    }

    private void OnDisable()
    {
        stir.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float selectInput = stir.MoveStraw.Move.ReadValue<float>();
        float currentPosition = transform.position.x;

        currentPosition += selectInput * speed * Time.deltaTime;
        currentPosition = Mathf.Clamp(currentPosition, -.87f, .22f);

        if (currentPosition != currentPos)
        {
            Debug.Log("test");
        }
        currentPos = currentPosition;

        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
    }
}
