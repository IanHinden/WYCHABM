using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBalls : MonoBehaviour
{
    private WritingControls writingControls;
    private float speed = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        writingControls = new WritingControls();
    }

    private void OnEnable()
    {
        writingControls.Enable();
    }

    private void OnDisable()
    {
        writingControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = writingControls.Move.Directions.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        if (movementInput != Vector2.zero)
        {
            //currentPosition.y += -1f * speed * Time.deltaTime;
            //currentPosition.y = Mathf.Clamp(currentPosition.y, -.04f, 0f);
            transform.position = currentPosition;
        } else
        {
            transform.position = new Vector2(0, 0);
        }

    }
}
