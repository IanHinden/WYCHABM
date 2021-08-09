using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschGameplay : MonoBehaviour
{
    FingerControls fingerControls;
    Vector2 movementInput;

    MenschAnimationController menschAnimationController;
    Tapper tapper;

    private float speed = 5f;
    void Awake()
    {
        menschAnimationController = FindObjectOfType<MenschAnimationController>();
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
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = fingerControls.Move.Directions.ReadValue<Vector2>();

        Vector3 currentPosition = tapper.transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;

        tapper.transform.position = currentPosition;
    }
}
