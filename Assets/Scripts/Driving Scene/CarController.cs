using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed;

    private Driving driving;

    ThreeSecondsLeft threeSecondsLeft;
    SceneSwitch sceneSwitch;

    bool lost = false;
    bool introOver = false;

    void Awake()
    {
        threeSecondsLeft = FindObjectOfType<ThreeSecondsLeft>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        driving = new Driving();
        StartCoroutine(IntroPause());
        StartCoroutine(WinOrLose());
    }

    private void OnEnable()
    {
        driving.Enable();
    }

    private void OnDisable()
    {
        driving.Disable();
    }

    void Update()
    {
        float selectInput = driving.Drive.Steer.ReadValue<float>();
        float currentPosition = transform.position.x;

        if (introOver == true)
        {
            currentPosition += selectInput * speed * Time.deltaTime;
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lost = true;
        driving.Disable();
        collision.transform.GetComponent<Animator>().enabled = false;
        threeSecondsLeft.LoseDisplay();
    }

    IEnumerator WinOrLose()
    {
        float deadline = sceneSwitch.ReturnTimeToSwitch() - threeSecondsLeft.ReturnTimeToEnd() + (3 * threeSecondsLeft.ReturnSingleMeasure());
        yield return new WaitForSeconds(deadline);
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
            threeSecondsLeft.WinDisplay();
        }
    }
}
