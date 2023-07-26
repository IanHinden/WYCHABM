using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstChorus : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    [SerializeField] GameplayArrows gameplayArrows;
    [SerializeField] detectionSquare detect;
    [SerializeField] GameObject playerside;

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

        StartCoroutine(Blink());
    }

    public void Reset()
    {
        gameplayArrows.transform.position = new Vector3(-142f, 1299f, 0);
        detect.resetScore();
    }

    private void SpawnGameplayArrows()
    {
        GameplayArrows gameplayArrowsGroup = Instantiate(gameplayArrows, new Vector3(-142f + 640f, 360f + 1299f, 0), Quaternion.identity);
        gameplayArrowsGroup.transform.SetParent(playerside.transform);
    }

    private IEnumerator Blink()
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
}
