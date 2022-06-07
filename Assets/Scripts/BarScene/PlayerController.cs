using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerActionControls playerActionControls;
    private Animator animator;

    [SerializeField] private float speed;
    public Vector2 position;
    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    public void OnDisable()
    {
        playerActionControls.Disable();
    }

    void FixedUpdate()
    {
        Vector2 movementInput = playerActionControls.OverheadMove.Move.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;
        if (movementInput != Vector2.zero)
        {
            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);
            animator.SetBool("moving", true);
        } else
        {
            animator.SetBool("moving", false);
        }
        transform.position = currentPosition;
    }
}
