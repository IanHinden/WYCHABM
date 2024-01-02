using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondChorus : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameplayArrows gameplayArrows;

    [SerializeField] detectionSquare detect;

    private Animator[] allAnimators;

    private float measure;
    private void Awake()
    {
        detectionSquare[] detectionSquares = FindObjectsOfType<detectionSquare>();

        allAnimators = new Animator[detectionSquares.Length];
        for (int i = 0; i < detectionSquares.Length; i++)
        {
            allAnimators[i] = detectionSquares[i].GetComponent<Animator>();
        }

        measure = timefunctions.ReturnSingleMeasure();
        StartCoroutine(Blink());
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

    public void Reset()
    {
        gameplayArrows.transform.localPosition = new Vector3(-7f, 1600f, 0);

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

    }
}
