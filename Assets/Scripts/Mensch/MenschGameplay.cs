using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschGameplay : MonoBehaviour
{
    FingerControls fingerControls;
    Vector2 movementInput;

    MenschAnimationController menschAnimationController;
    Tapping tapping;
    SpriteRenderer tapper;
    SpriteRenderer tapped;

    private float speed = 5f;
    private bool pressing = false;
    void Awake()
    {
        menschAnimationController = FindObjectOfType<MenschAnimationController>();
        tapping = FindObjectOfType<Tapping>();
        tapper = FindObjectOfType<Tapper>().GetComponent<SpriteRenderer>();
        tapped = FindObjectOfType<Tapped>().GetComponent<SpriteRenderer>();

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

            tapped.enabled = true;
            tapper.enabled = false;

            while (countdown > 0)
            {
                countdown -= Time.deltaTime;
                yield return null;
            }

            tapped.enabled = false;
            tapper.enabled = true;
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
