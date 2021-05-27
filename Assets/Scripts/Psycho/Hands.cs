using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    private StabControls stabControls;

    private SpriteRenderer handReady;
    private SpriteRenderer handStab;

    private float speed = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        stabControls = new StabControls();
        handReady = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        handStab = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        stabControls.Enable();
    }

    private void OnDisable()
    {
        stabControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float stabInput = stabControls.Stab.Kill.ReadValue<float>();
        Vector2 movementInput = stabControls.Move.Directions.ReadValue<Vector2>();

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;

        if (stabInput == 0)
        {
            handStab.enabled = false;
            handReady.enabled = true;

            transform.position = currentPosition;
        } else
        {
            handStab.enabled = true;
            handReady.enabled = false;
        }
    }
}
