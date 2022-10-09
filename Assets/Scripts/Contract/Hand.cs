﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;

    private PlayerActionControls playerActionControls;
    Print print;
    private bool moved = false;

    private float speed = 5f;
    
    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
        print = FindObjectOfType<Print>();

        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    void Update()
    {
        Vector2 movementInput = playerActionControls.OverheadMove.Move.ReadValue<Vector2>();

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
        //float deadline = (threeSecondsLeft.ReturnTimeToEnd()) + threeSecondsLeft.ReturnSingleMeasure();
        yield return new WaitForSeconds(3f);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        if (moved)
        {
            uihandler.LoseDisplay();
        }
        else
        {
            //threeSecondsLeft.DisplayScoreCard();
            uihandler.WinDisplay();
        }
    }
}
