﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstChorus : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scoreHandler;

    [SerializeField] Chorus1AnimationController chorus1AnimationController;

    [SerializeField] GameplayArrows gameplayArrows;
    //[SerializeField] detectionSquare detect;
    //[SerializeField] GameObject playerside;
    [SerializeField] MissBar missBar;
    [SerializeField] DetectionSquareFirstChorus rightSquare;
    [SerializeField] DetectionSquareFirstChorus downSquare;
    [SerializeField] DetectionSquareFirstChorus upSquare;
    [SerializeField] DetectionSquareFirstChorus leftSquare;

    private Animator[] allAnimators;

    private float measure;

    private void Awake()
    {
        DetectionSquareFirstChorus[] detectionSquares = FindObjectsOfType<DetectionSquareFirstChorus>();

        DetectionSquareFirstChorus.GoodPoint += AddGoodPoint;
        DetectionSquareFirstChorus.PerfectPoint += AddPerfectPoint;

        allAnimators = new Animator[detectionSquares.Length];
        for (int i = 0; i < detectionSquares.Length; i++)
        {
            allAnimators[i] = detectionSquares[i].GetComponent<Animator>();
        }

        measure = timefunctions.ReturnSingleMeasure();
        StartCoroutine(Blink());
    }

    private void AddGoodPoint()
    {
        scoreHandler.IncrementTotalPointsPartOne(true);
    }

    private void AddPerfectPoint()
    {
        scoreHandler.IncrementTotalPointsPartOne(false);
    }

    public IEnumerator Blink()
    {
        chorus1AnimationController.AnimationLogic();
        while (true)
        {
            foreach (Animator animator in allAnimators)
            {
                animator.SetTrigger("Blink");
            }

            yield return new WaitForSeconds(measure / 2);
        }
    }

    private void DestroyAllText()
    {
        int childCount = missBar.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Destroy(missBar.transform.GetChild(i).gameObject);
        }

        int childCountRight = rightSquare.transform.childCount;

        for (int i = 0; i < childCountRight; i++)
        {
            Destroy(rightSquare.transform.GetChild(i).gameObject);
        }

        int childCountDown = downSquare.transform.childCount;

        for (int i = 0; i < childCountDown; i++)
        {
            Destroy(downSquare.transform.GetChild(i).gameObject);
        }

        int childCountUp = upSquare.transform.childCount;

        for (int i = 0; i < childCountUp; i++)
        {
            Destroy(upSquare.transform.GetChild(i).gameObject);
        }

        int childCountLeft = leftSquare.transform.childCount;

        for (int i = 0; i < childCountLeft; i++)
        {
            Destroy(leftSquare.transform.GetChild(i).gameObject);
        }
    }

    public void IncrementTotalScore()
    {
        Debug.Log("First Chorus");
    }

    public void Reset()
    {
        gameplayArrows.transform.localPosition = new Vector3(-42f, 751f, 0);

        foreach (Transform child in gameplayArrows.transform)
        {
            BoxCollider2D boxCollider = child.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                // Enable the BoxCollider2D component
                boxCollider.enabled = true;
            }

            // Check if the child has an Image component (assuming you're using UI elements)
            Image image = child.GetComponent<Image>();
            if (image != null)
            {
                // Enable the Image component
                image.enabled = true;
            }
        }

        chorus1AnimationController.Reset();
        //detect.resetScore();
        DestroyAllText();
    }
}
