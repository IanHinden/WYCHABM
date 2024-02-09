using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Straw : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] MixAnimationController animationController;
    [SerializeField] MixSFXController mixSFXController;

    private GameControls gamecontrols;
    private float speed = 3.5f;
    private float moveAmount = 0f;
    private float currentPos;

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

    void FixedUpdate()
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
        }

        if(moveAmount > 150 && gameOver == false)
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
        if (moveAmount >= 150 && gameOver == false)
        {
            win();
        }
        else if (moveAmount < 150)
        {
            lose();
        }
        gameOver = true;
    }

    private void win()
    {
        scorehandler.IncrementScore();
        gameOver = true;

        animationController.WinAnimation();

        //mixedDrink.GetComponent<SpriteRenderer>().color = new Color(255, 138, 83, 255);
    }

    private void lose()
    {
        animationController.LoseAnimation();
    }

    public void Reset()
    {
        moveAmount = 0;
        stirring = false;
        animationController.Reset();
    }
}
