using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerActionControls playerActionControls;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    public Vector2 position;
    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 movementInput = playerActionControls.OverheadMove.Move.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        Debug.Log(movementInput);
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
