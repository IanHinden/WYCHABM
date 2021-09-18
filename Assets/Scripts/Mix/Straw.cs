using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Straw : MonoBehaviour
{
    private Stir stir;
    private float speed = 3.5f;
    private float moveAmount = 0f;
    private float currentPos;

    bool gameOver = false;

    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;

    SpriteRenderer window;

    public GameObject sun;
    MixedDrink mixedDrink;

    void Awake()
    {
        stir = new Stir();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        window = FindObjectOfType<Window>().GetComponent<SpriteRenderer>();
        mixedDrink = FindObjectOfType<MixedDrink>();

        sun = GameObject.Find("Sun");
        sun.SetActive(false);

        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        stir.Enable();
    }

    private void OnDisable()
    {
        stir.Disable();
    }

    void FixedUpdate()
    {
        float selectInput = stir.MoveStraw.Move.ReadValue<float>();
        float currentPosition = transform.position.x;

        currentPosition += selectInput * speed * Time.deltaTime;
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
        float deadline = sceneSwitch.ReturnTimeToSwitch() - threeSecondsLeft.ReturnTimeToEnd() + (3 * threeSecondsLeft.ReturnSingleMeasure());
        yield return new WaitForSeconds(deadline);
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        stir.Disable();
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
        gameOver = true;
        StartCoroutine(ColorChanges());

        GameObject moon = GameObject.Find("Moon");
        moon.SetActive(false);

        sun.SetActive(true);

        mixedDrink.GetComponent<SpriteRenderer>().color = new Color(255, 138, 83, 255);
    }

    private void lose()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * -300);
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
}
