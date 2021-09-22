using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    SuccessOrFail successOrFail;
    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;
    private WritingControls writingControls;
    Print print;
    private bool moved = false;

    private float speed = 5f;
    
    private void Awake()
    {
        writingControls = new WritingControls();
        print = FindObjectOfType<Print>();

        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        successOrFail = gameObject.AddComponent<SuccessOrFail>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        writingControls.Enable();
    }

    private void OnDisable()
    {
        writingControls.Disable();
    }

    void Update()
    {
        Vector2 movementInput = writingControls.Move.Directions.ReadValue<Vector2>();

        if (movementInput.x != 0 || movementInput.y != 0)
        {
            moved = true;
        }

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;
        currentPosition.x = Mathf.Clamp(currentPosition.x, 2f, 3.5f);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -1.8f, -1.2f);

        print.InkSpawner();

        transform.position = currentPosition;
    }

    IEnumerator WinOrLose()
    {
        float deadline = sceneSwitch.ReturnTimeToSwitch() - threeSecondsLeft.ReturnTimeToEnd() + (3 * threeSecondsLeft.ReturnSingleMeasure());
        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (moved)
        {
            successOrFail.LoseDisplay();
        }
        else
        {
            successOrFail.WinDisplay();
        }
    }
}
