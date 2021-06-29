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

    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;

    void Awake()
    {
        stir = new Stir();
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
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

    // Update is called once per frame
    void FixedUpdate()
    {
        float selectInput = stir.MoveStraw.Move.ReadValue<float>();
        float currentPosition = transform.position.x;

        currentPosition += selectInput * speed * Time.deltaTime;
        currentPosition = Mathf.Clamp(currentPosition, -.87f, .22f);

        if (currentPosition != currentPos)
        {
            moveAmount++;
        }

        if(moveAmount > 150)
        {
            DetermineWinOrLoss();
        }
        currentPos = currentPosition;

        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
    }

    IEnumerator WinOrLose()
    {
        float deadline = sceneSwitch.ReturnTimeToSwitch() - threeSecondsLeft.ReturnTimeToEnd() + (3 * threeSecondsLeft.ReturnSingleMeasure());
        while (deadline > 0)
        {
            deadline -= Time.deltaTime;
            yield return null;
        }
        DetermineWinOrLoss();
    }

    private void DetermineWinOrLoss()
    {
        stir.Disable();
        if (moveAmount >= 150)
        {
            win();
        }
        else
        {
            lose();
        }
    }

    private void win()
    {
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        Image window = canvas.transform.Find("Window").GetComponent<Image>();
        window.GetComponent<Image>().color = new Color32(168, 122, 0, 255);

        Image mixedDrink = canvas.transform.Find("MixedDrink").GetComponent<Image>();
        mixedDrink.GetComponent<Image>().color = new Color32(255, 138, 83, 255);
    }

    private void lose()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * -300);
    }
}
