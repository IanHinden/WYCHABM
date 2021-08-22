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
    Tapped tapped;
    SpriteRenderer tapperSR;
    SpriteRenderer tappedSR;

    ToolkitButton toolKitButton;
    ShareButton shareButton;

    BoxCollider2D fingerTipUnTap;
    BoxCollider2D toolKitButtonCol;
    BoxCollider2D shareButtonCol;

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

        toolKitButton = FindObjectOfType<ToolkitButton>();
        toolKitButtonCol = toolKitButton.GetComponent<BoxCollider2D>();

        shareButton = FindObjectOfType<ShareButton>();
        shareButtonCol = shareButton.GetComponent<BoxCollider2D>();

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
            if(toolKitButton.ButtonPress() == true)
            {
                menschAnimationController.SafetyExit();
                menschAnimationController.StatusEnter();
            }

            if (shareButton.ButtonPress() == true)
            {
                Debug.Log("Win animation");
            }

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
        yield return new WaitForSeconds(1);
        menschAnimationController.SafetyEnter();
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
