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

    //ToolkitButton toolKitButton;
    //ShareButton shareButton;

    private float timeToLeave = 3f;

    private float speed = 5f;
    private bool pressing = false;
    void Awake()
    {
        CreepyDriver.BonusWin += CoolFunc;

        tapperSR = tapper.GetComponent<SpriteRenderer>();
        tappedSR = tapped.GetComponent<SpriteRenderer>();

        tappedBC = tapped.GetComponent<BoxCollider2D>();

        //toolKitButton = FindObjectOfType<ToolkitButton>();

        //shareButton = FindObjectOfType<ShareButton>();


        gamecontrols = new GameControls();
        gamecontrols.Move.Select.performed += x => StartPress();
        //StartCoroutine(ScreenFade());
    }

    private void CoolFunc(int amount)
    {
        menschAnimationController.BonusAnimations();
        scorehandler.IncrementBonusScore();
    }

    private void StartPress()
    {
        /*Debug.Log("Why?");
        tappedSR.enabled = true;
        tapperSR.enabled = false;

        yield return new WaitForSeconds(.1f);

        tappedSR.enabled = false;
        tapperSR.enabled = true;
        Debug.Log("Why not?");*/
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
        /*if (pressing == false)
        {
            pressing = true;
            /*if(toolKitButton.ButtonPress() == true)
            {
                menschAnimationController.SafetyExit();
                menschAnimationController.StatusEnter();
            }

            if (shareButton.ButtonPress() == true)
            {
                gamecontrols.Disable();
                scorehandler.IncrementScore();
                uihandler.WinDisplay();
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
        }*/
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    /*IEnumerator ScreenFade()
    {
        yield return new WaitForSeconds(1);
        menschAnimationController.ScreenFade();
        yield return new WaitForSeconds(1);
        menschAnimationController.SafetyEnter();
    }*/

    // Update is called once per frame
    void Update()
    {
        timeToLeave -= Time.deltaTime;

        movementInput = gamecontrols.Move.Directions.ReadValue<Vector2>();

        Vector3 currentPosition = tapping.transform.position;
        currentPosition.x += movementInput.x * speed * Time.deltaTime;
        currentPosition.y += movementInput.y * speed * Time.deltaTime;

        if (timeToLeave > 0)
        {
            //currentPosition.x = Mathf.Clamp(currentPosition.x, -1.45f, 1.70f);
            //currentPosition.y = Mathf.Clamp(currentPosition.y, -6f, 0f);
        }

        tapping.transform.position = currentPosition;
    }

    public void Clicked()
    {
        Debug.Log("Clicked");
    }
}
