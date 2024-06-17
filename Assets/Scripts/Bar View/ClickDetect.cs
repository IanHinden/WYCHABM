using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetect : MonoBehaviour
{
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] pauseManager PM;

    private bool clicked = false;
    private BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (PM.IsGamePaused() == false)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (clicked == false)
                {
                    clicked = true;
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

                    if (collider.bounds.Contains(mousePosition))
                    {
                        scoreHandler.IncrementBonusScore(9);
                    }
                }
            }
        }
    }

    public void ResetClicked()
    {
        clicked = false;
    }
}
