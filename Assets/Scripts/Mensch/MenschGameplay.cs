using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenschGameplay : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] UIHandler uihandler;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] MenschAnimationController menschAnimationController;

    GameControls gamecontrols;
    Vector2 movementInput;

    [SerializeField] GameObject tapping;
    [SerializeField] GameObject tapper;
    [SerializeField] GameObject tapped;

    [SerializeField] GameObject yellowClick;

    SpriteRenderer tapperSR;
    SpriteRenderer tappedSR;

    BoxCollider2D tappedBC;

    private float speed = 5f;

    void Awake()
    {
        gamecontrols = new GameControls();
        gamecontrols.Move.Select.performed += x => StartPress();

        CreepyDriver.BonusWin += BonusWinEvents;
        ToolkitButton.Win += Win;

        tapperSR = tapper.GetComponent<SpriteRenderer>();
        tappedSR = tapped.GetComponent<SpriteRenderer>();

        tappedBC = tapped.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    private void BonusWinEvents()
    {
        Debug.Log("Bonus win");
        //menschAnimationController.BonusAnimations();
        scorehandler.IncrementBonusScore();
    }

    private void Win()
    {
        gamecontrols.Disable();
        uihandler.WinDisplay();
        scorehandler.IncrementScore();
    }

    private void StartPress()
    {
        StartCoroutine(pressScreen());
    }

    IEnumerator pressScreen()
    {
        tappedSR.enabled = true;
        tapperSR.enabled = false;
        tappedBC.enabled = true;

        yield return new WaitForSeconds(.1f);

        tappedSR.enabled = false;
        tapperSR.enabled = true;
        tappedBC.enabled = false;
    }

    void Update()
    {
        movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        Vector3 currentPosition = tapping.transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;

        //currentPosition.x = Mathf.Clamp(currentPosition.x, -1.45f, 1.70f);
        //currentPosition.y = Mathf.Clamp(currentPosition.y, -6f, 0f);

        tapping.transform.position = currentPosition;
    }

    public IEnumerator WinOrLose()
    {
        menschAnimationController.ScreenFade();
        yield return new WaitForSeconds(2);
        menschAnimationController.enableScreen();
        yield return new WaitForSeconds(1);
    }

    public void Reset()
    {
        Debug.Log("reset");
    }
}
