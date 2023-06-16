using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBuilder : MonoBehaviour
{
    private GameControls gamecontrols;

    [SerializeField] GameObject upArrow;
    [SerializeField] GameObject downArrow;
    [SerializeField] GameObject leftArrow;
    [SerializeField] GameObject rightArrow;

    float speed = 200f;
    void Awake()
    {
        gamecontrols = new GameControls();

        gamecontrols.Select.UpSelect.performed += x => spawnUpArrow();
        gamecontrols.Select.DownSelect.performed += x => spawnDownArrow();
        gamecontrols.Select.LeftSelect.performed += x => spawnLeftArrow();
        gamecontrols.Select.RightSelect.performed += x => spawnRightArrow();
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    private void spawnDownArrow()
    {
        Vector3 spawnPosition = transform.position + new Vector3(-189f, 0f, 0f); // Calculate the spawn position
        //Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 90f); // Define the rotation
        GameObject DownArrow = Instantiate(leftArrow, spawnPosition, Quaternion.identity);
        DownArrow.transform.SetParent(transform);
        Rigidbody arrowRB = DownArrow.GetComponent<Rigidbody>();
        arrowRB.velocity = Vector3.down * speed;
    }

    private void spawnUpArrow()
    {
        Vector3 spawnPosition = transform.position + new Vector3(-284.1f, 0f, 0f); // Calculate the spawn position
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 180f); // Define the rotation
        GameObject UpArrow = Instantiate(leftArrow, spawnPosition, spawnRotation);
        UpArrow.transform.SetParent(transform);
        Rigidbody arrowRB = UpArrow.GetComponent<Rigidbody>();
        arrowRB.velocity = Vector3.down * speed;
    }

    private void spawnLeftArrow()
    {
        Vector3 spawnPosition = transform.position + new Vector3(-379.8f, 0f, 0f); // Calculate the spawn position
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, -90f); // Define the rotation
        GameObject LeftArrow = Instantiate(leftArrow, spawnPosition, spawnRotation);
        LeftArrow.transform.SetParent(transform);
        Rigidbody arrowRB = LeftArrow.GetComponent<Rigidbody>();
        arrowRB.velocity = Vector3.down * speed;
    }
    private void spawnRightArrow()
    {
        Vector3 spawnPosition = transform.position + new Vector3(-93.3f, 0f, 0f); // Calculate the spawn position
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 90f); // Define the rotation
        GameObject RightArrow = Instantiate(leftArrow, spawnPosition, spawnRotation);
        RightArrow.transform.SetParent(transform);
        Rigidbody arrowRB = RightArrow.GetComponent<Rigidbody>();
        arrowRB.velocity = Vector3.down * speed;
    }
}
