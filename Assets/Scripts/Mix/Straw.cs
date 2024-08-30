using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Straw : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] UIHandler uihandler;

    [SerializeField] MixAnimationController animationController;
    [SerializeField] MixSFXController mixSFXController;

    [SerializeField] SpriteRenderer mixedDrinkSR;

    private GameControls gamecontrols;
    private float speed = 3.5f;
    private float moveAmount = 0f;
    private float currentPos;
    private float fadeSpeed = 0.01f;

    private float alpha = 0f;

    private int winningAmount = 120;

    bool stirring = false;
    bool gameOver = false;

    void Awake()
    {
        gamecontrols = new GameControls();

        //StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        gamecontrols.Enable();
    }

    private void OnDisable()
    {
        gamecontrols.Disable();
    }

    void Update()
    {
        Vector2 selectInput = gamecontrols.Move.Directions.ReadValue<Vector2>();
        float currentPosition = transform.position.x;

        currentPosition += selectInput.x * speed * Time.deltaTime;
        currentPosition = Mathf.Clamp(currentPosition, -.87f, .22f);

        if(selectInput.x != 0)
        {
            if(stirring == false)
            {
                stirring = true;
                mixSFXController.PlayStirringIce();
            }
        } else
        {
            mixSFXController.PauseStirringIce();
            stirring = false;
        }

        if (currentPosition != currentPos && gameOver == false)
        {
            moveAmount++;
            alpha = Mathf.Clamp(alpha + fadeSpeed, 0f, 1f);
            mixedDrinkSR.color = new Color(1f, 1f, 1f, alpha);
        }

        if(moveAmount > winningAmount && gameOver == false)
        {
            DetermineWinOrLoss();
        }
        currentPos = currentPosition;

        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
    }

    public IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(7));
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        gamecontrols.Disable();
        if (moveAmount >= winningAmount && gameOver == false)
        {
            win();
        }
        else if (moveAmount < winningAmount)
        {
            lose();
        }
        gameOver = true;
    }

    private void win()
    {
        scorehandler.IncrementScore(3);
        gameOver = true;

        animationController.WinAnimation();
        uihandler.WinDisplay();

        //mixedDrink.GetComponent<SpriteRenderer>().color = new Color(255, 138, 83, 255);
    }

    private void lose()
    {
        uihandler.LoseDisplay();
        animationController.LoseAnimation();
    }

    public void Reset()
    {
        moveAmount = 0;
        gameOver = false;
        stirring = false;
        animationController.Reset();
        alpha = 0f;
        mixedDrinkSR.color = new Color(1, 1, 1, 0);
    }
}
