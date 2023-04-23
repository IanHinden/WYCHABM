using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmGameSetUp : MonoBehaviour
{
    private GameControls gameControls;
    public CircleCollider2D leftArrowDetector;
    public CircleCollider2D upArrowDetector;
    public CircleCollider2D downArrowDetector;
    public CircleCollider2D rightArrowDetector;
    public List<GameObject> leftArrows;
    public List<GameObject> upArrows;
    public List<GameObject> downArrows;
    public List<GameObject> rightArrows;
    public List<GameObject> leftArrowExamples;
    public List<GameObject> downArrowExamples;
    public List<GameObject> upArrowExamples;
    public List<GameObject> rightArrowExamples;

    void Awake()
    {
        gameControls = new GameControls();
    }

    private void OnEnable()
    {
        gameControls.Enable();
    }

    public void OnDisable()
    {
        gameControls.Disable();
    }

    public void addExampleArrow(string direction)
    {
        if (direction == "Left" || direction == "left")
        {
            leftArrowExamples[0].SetActive(true);
            leftArrowExamples.Remove(leftArrowExamples[0]);
        }
        if (direction == "Right" || direction == "right")
        {
            rightArrowExamples[0].SetActive(true);
            rightArrowExamples.Remove(rightArrowExamples[0]);
        }
        if (direction == "Up" || direction == "up")
        {
            upArrowExamples[0].SetActive(true);
            upArrowExamples.Remove(upArrowExamples[0]);
        }
        if (direction == "Down" || direction == "down")
        {
            downArrowExamples[0].SetActive(true);
            downArrowExamples.Remove(downArrowExamples[0]);
        }
    }

    public void addArrow(string direction)
    {
        if (direction == "Left" || direction == "left")
        {
            leftArrows[0].SetActive(true);
            leftArrows.Remove(leftArrows[0]);
        }
        if (direction == "Right" || direction == "right")
        {
            rightArrows[0].SetActive(true);
            rightArrows.Remove(rightArrows[0]);
        }
        if (direction == "Up" || direction == "up")
        {
            upArrows[0].SetActive(true);
            upArrows.Remove(upArrows[0]);
        }
        if (direction == "Down" || direction == "down")
        {
            downArrows[0].SetActive(true);
            downArrows.Remove(downArrows[0]);
        }
    }

    void Update()
    {
        Vector2 keyInput = gameControls.Move.Directions.ReadValue<Vector2>();

        if (keyInput.x < 0)
        {
            //left key
            leftArrowDetector.enabled = true;
            StartCoroutine(buttonReset(leftArrowDetector));
        }
        if (keyInput.x > 0)
        {
            //right key
            rightArrowDetector.enabled = true;
            StartCoroutine(buttonReset(rightArrowDetector));
        }
        if (keyInput.y < 0)
        {
            //down key
            downArrowDetector.enabled = true;
            StartCoroutine(buttonReset(downArrowDetector));
        }
        if (keyInput.y > 0)
        {
            //up key
            upArrowDetector.enabled = true;
            StartCoroutine(buttonReset(upArrowDetector));
        }
    }

    IEnumerator buttonReset(CircleCollider2D detectorToReset)
    {
        yield return new WaitForSeconds(0.01f);
        detectorToReset.enabled = false;
    }
}
