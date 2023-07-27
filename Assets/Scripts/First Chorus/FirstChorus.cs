using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstChorus : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameplayArrows gameplayArrows;
    [SerializeField] detectionSquare detect;
    [SerializeField] GameObject playerside;
    [SerializeField] MissBar missBar;
    [SerializeField] detectionSquare rightSquare;
    [SerializeField] detectionSquare downSquare;
    [SerializeField] detectionSquare upSquare;
    [SerializeField] detectionSquare leftSquare;

    private Animator[] allAnimators;

    private float measure;

    private void Awake()
    {
        SpawnGameplayArrows();

        detectionSquare[] detectionSquares = FindObjectsOfType<detectionSquare>();

        allAnimators = new Animator[detectionSquares.Length];
        for (int i = 0; i < detectionSquares.Length; i++)
        {
            allAnimators[i] = detectionSquares[i].GetComponent<Animator>();
        }

        measure = timefunctions.ReturnSingleMeasure();
        Reset();
        //StartCoroutine(Blink());
    }

    private void SpawnGameplayArrows()
    {
        GameplayArrows currGameplayArrows = FindObjectOfType<GameplayArrows>();
        if (currGameplayArrows != null) Destroy(currGameplayArrows);
        GameplayArrows gameplayArrowsGroup = Instantiate(gameplayArrows, new Vector3(-142f + 640f, 360f + 1299f, 0), Quaternion.identity);
        gameplayArrowsGroup.transform.SetParent(playerside.transform);
    }

    public IEnumerator Blink()
    {
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

    public void Reset()
    {
        SpawnGameplayArrows();
        //gameplayArrows.transform.position = new Vector3(-142f, 1299f, 0);
        detect.resetScore();
        DestroyAllText();
    }
}
