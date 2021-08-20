﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschGameplay : MonoBehaviour
{
    FingerControls fingerControls;
    Vector2 movementInput;

    MenschAnimationController menschAnimationController;
    Tapping tapping;
    Tapper tapper;
    Tapped tapped;
    SpriteRenderer tapperSR;
    SpriteRenderer tappedSR;

    BoxCollider2D fingerTipUnTap;
    BoxCollider2D toolKitButton;

    private float speed = 5f;
    private bool pressing = false;
    void Awake()
    {
        menschAnimationController = FindObjectOfType<MenschAnimationController>();
        tapping = FindObjectOfType<Tapping>();

        tapper = FindObjectOfType<Tapper>();
        tapped = FindObjectOfType<Tapped>();

        tapperSR = tapper.GetComponent<SpriteRenderer>();
        tappedSR = tapped.GetComponent<SpriteRenderer>();

        fingerTipUnTap = tapping.GetComponent<BoxCollider2D>();
        toolKitButton = FindObjectOfType<ToolkitButton>().GetComponent<BoxCollider2D>();

        fingerControls = new FingerControls();
        fingerControls.Press.FingerPress.performed += x => StartPress();
        StartCoroutine(ScreenFade());
    }

    private void StartPress()
    {
        StartCoroutine(pressScreen());
    }

    IEnumerator pressScreen()
    {
        if (pressing == false)
        {
            pressing = true;
            float countdown = .05f;

            tappedSR.enabled = true;
            tapperSR.enabled = false;

            while (countdown > 0)
            {
                countdown -= Time.deltaTime;
                yield return null;
            }

            tappedSR.enabled = false;
            tapperSR.enabled = true;
            pressing = false;
        }
    }

    private void OnEnable()
    {
        fingerControls.Enable();
    }

    private void OnDisable()
    {
        fingerControls.Disable();
    }

    IEnumerator ScreenFade()
    {
        yield return new WaitForSeconds(1);
        menschAnimationController.ScreenFade();
        yield return new WaitForSeconds(2);
        menschAnimationController.SafetyEnter();
        yield return new WaitForSeconds(2);
        menschAnimationController.SafetyExit();
        yield return new WaitForSeconds(2);
        menschAnimationController.StatusEnter();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = fingerControls.Move.Directions.ReadValue<Vector2>();

        Vector3 currentPosition = tapping.transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -1.45f, 1.70f);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -6f, 0f);

        tapping.transform.position = currentPosition;
    }
}
