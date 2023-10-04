using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Straw : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;

    [SerializeField] MixAnimationController animationController;

    private GameControls gamecontrols;
    private float speed = 3.5f;
    private float moveAmount = 0f;
    private float currentPos;

    bool gameOver = false;

    SpriteRenderer window;

    //public GameObject sun;
    //MixedDrink mixedDrink;

    void Awake()
    {
        gamecontrols = new GameControls();
        //window = FindObjectOfType<Window>().GetComponent<SpriteRenderer>();
        //mixedDrink = FindObjectOfType<MixedDrink>();

        //sun = GameObject.Find("Sun");
        //sun.SetActive(false);

        StartCoroutine(WinOrLose());
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

    IEnumerator WinOrLose()
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

        //Win animation
        //StartCoroutine(ColorChanges());

        //GameObject moon = GameObject.Find("Moon");
        //moon.SetActive(false);

        //sun.SetActive(true);

        //mixedDrink.GetComponent<SpriteRenderer>().color = new Color(255, 138, 83, 255);
    }

    private void lose()
    {
        //Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        //rb.AddForce(transform.up * -300);
        //Lose Animation
        animationController.LoseAnimation();
    }

    private IEnumerator ColorChanges()
    {
        float timeElapsed = 0;

        while(timeElapsed < 1f)
        {
            window.color = Color.Lerp(new Color(0f, 0.13f, 0.45f, 1f), new Color(.79f, .33f, .19f, 1f), timeElapsed/1f)/*new Color32(168, 122, 0, 255)*/;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        window.color = new Color(.79f, .33f, .19f, 1f);
    }

    public void Reset()
    {
        Debug.Log("Resetting");
    }
}
