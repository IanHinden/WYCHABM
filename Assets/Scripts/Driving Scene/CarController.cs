using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] UIHandler uihandler;
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scorehandler;
    [SerializeField] GameObject wheel;
    public float speed;
    public float wheelSpeed = 30;

    private GameControls gamecontrols;
    private Rigidbody2D wheelsrb;

    bool lost = false;
    bool introOver = false;

    void Awake()
    {
        wheelsrb = wheel.GetComponent<Rigidbody2D>();

        gamecontrols = new GameControls();
        StartCoroutine(IntroPause());
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

    void Update()
    {
        Vector2 selectInput = gamecontrols.Move.Directions.ReadValue<Vector2>();
        float currentPosition = transform.position.x;

        if (introOver == true)
        {
            currentPosition += selectInput.x * speed * Time.deltaTime;
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);

            if (selectInput.x == -1)
            {
                wheelsrb.rotation += speed * Time.deltaTime;
            }
            else if (selectInput.x == 1)
            {
                wheelsrb.rotation -= speed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lost = true;
        gamecontrols.Disable();
        collision.transform.GetComponent<Animator>().enabled = false;
        uihandler.LoseDisplay();
    }

    IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(timefunctions.ReturnCountMeasure(11));
        DetermineWinOrLoss();
    }

    IEnumerator IntroPause()
    {
        yield return new WaitForSeconds(5);
        introOver = true;
    }

    private void DetermineWinOrLoss()
    {
        if (lost == false)
        {
            scorehandler.IncrementScore();
            uihandler.WinDisplay();
        } else
        {
            uihandler.LoseDisplay();
        }
    }
}
