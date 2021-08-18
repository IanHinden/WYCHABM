using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschGameplay : MonoBehaviour
{
    FingerControls fingerControls;
    Vector2 movementInput;

    MenschAnimationController menschAnimationController;
    Tapping tapping;
    Tapper tapper;

    private float speed = 5f;
    void Awake()
    {
        menschAnimationController = FindObjectOfType<MenschAnimationController>();
        tapping = FindObjectOfType<Tapping>();
        tapper = FindObjectOfType<Tapper>();
        fingerControls = new FingerControls();
        StartCoroutine(ScreenFade());
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
