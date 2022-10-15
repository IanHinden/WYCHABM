using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBalls : MonoBehaviour
{
    private GameControls gamecontrols;
    private float speed = 5f;
    // Start is called before the first frame update
    void Awake()
    {
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
        Vector2 movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        if (movementInput != Vector2.zero)
        {
            currentPosition.y += -1f * speed * Time.deltaTime;
            currentPosition.y = Mathf.Clamp(currentPosition.y, -.04f, 0f);
            transform.position = currentPosition;
        } else
        {
            transform.position = new Vector2(0, 0);
        }

    }
}
