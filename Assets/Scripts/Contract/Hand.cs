using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject Pointing;
    [SerializeField] GameObject Clapping;
    [SerializeField] GameObject WatchingObjects;
    [SerializeField] GameObject Watching1;
    [SerializeField] GameObject Watching2;

    private GameControls gamecontrols;
    private new Print print;
    private bool moved = false;

    private float speed = 5f;
    
    private void Awake()
    {
        gamecontrols = new GameControls();
        print = FindObjectOfType<Print>();
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    public bool getMoved()
    {
        return moved;
    }

    public void resetMoved()
    {
        moved = false;
    }

    void Update()
    {
        Vector2 movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        if (movementInput.x != 0 || movementInput.y != 0)
        {
            moved = true;
            Pointing.SetActive(false);
            Clapping.SetActive(false);
            WatchingObjects.SetActive(true);
            Watching1.SetActive(false);
            Watching2.SetActive(true);
        } else
        {
            Watching1.SetActive(true);
            Watching2.SetActive(false);
        }

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;
        //currentPosition.x = Mathf.Clamp(currentPosition.x, 2f, 3.5f);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -2.5f, 1.6f);

        print.InkSpawner();

        transform.position = currentPosition;
    }
}
