using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondChorus : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scoreHandler;

    [SerializeField] GameplayArrows gameplayArrows;

    [SerializeField] DetectionSquareSecondChorus detect;

    [SerializeField] Animator avaAnimator;
    [SerializeField] Animator richmanAnimator;
    [SerializeField] Animator ianAnimator;

    [SerializeField] SpriteRenderer avaSR;
    [SerializeField] SpriteRenderer richmanSR;
    [SerializeField] SpriteRenderer ianSR;

    private Animator[] allAnimators;

    private float measure;
    private void Awake()
    {
        DetectionSquareSecondChorus[] detectionSquares = FindObjectsOfType<DetectionSquareSecondChorus>();

        DetectionSquareSecondChorus.GoodPoint += AddGoodPoint;
        DetectionSquareSecondChorus.PerfectPoint += AddPerfectPoint;

        allAnimators = new Animator[detectionSquares.Length];
        for (int i = 0; i < detectionSquares.Length; i++)
        {
            allAnimators[i] = detectionSquares[i].GetComponent<Animator>();
        }

        measure = timefunctions.ReturnSingleMeasure();
        //StartCoroutine(Blink());
    }

    private void AddGoodPoint()
    {
        scoreHandler.IncrementTotalPointsPartTwo(true);
    }

    private void AddPerfectPoint()
    {
        scoreHandler.IncrementTotalPointsPartTwo(false);
    }

    private IEnumerator CharacterAnimation()
    {
        avaAnimator.enabled = true;
        avaAnimator.Play("Ava");
        yield return new WaitForSeconds(measure * 4);
        richmanAnimator.enabled = true;
        richmanAnimator.Play("Richman");
        yield return new WaitForSeconds(measure * 4);
        ianAnimator.enabled = true;
        ianAnimator.Play("Ian");
    }

    public IEnumerator Blink()
    {
        StartCoroutine(CharacterAnimation());
        while (true)
        {
            foreach (Animator animator in allAnimators)
            {
                animator.SetTrigger("Blink");
            }

            yield return new WaitForSeconds(measure / 2);
        }
    }

    public void Reset()
    {
        gameplayArrows.transform.localPosition = new Vector3(224f, 1570f, 0);

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

        avaAnimator.enabled = false;
        richmanAnimator.enabled = false;
        ianAnimator.enabled = false;

        avaSR.color = new Color(1, 1, 1, 0);
        richmanSR.color = new Color(1, 1, 1, 0);
        ianSR.color = new Color(1, 1, 1, 0);
    }
}
