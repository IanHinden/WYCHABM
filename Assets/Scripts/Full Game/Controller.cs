using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameControls gameControls;
    private Animator animator;

    [SerializeField] private float speed;
    public Vector2 position;
    private void Awake()
    {
        gameControls = new GameControls();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gameControls.Enable();
    }

    public void OnDisable()
    {
        gameControls.Disable();
    }

    void FixedUpdate()
    {
        Vector2 movementInput = gameControls.Move.Directions.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;
        if (movementInput != Vector2.zero)
        {
            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
        transform.position = currentPosition;
    }
}
