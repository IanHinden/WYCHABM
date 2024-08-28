using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdChorus : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] ScoreHandler scoreHandler;

    [SerializeField] GameplayArrows gameplayArrows;

    [SerializeField] DetectionSquareThirdChorus detect;

    [SerializeField] Animator ianLightAnim;
    [SerializeField] Animator ianSilhouetteAnim;
    [SerializeField] Animator avaLightAnim;
    [SerializeField] Animator avaSilhouetteAnim;
    [SerializeField] Animator richmanLightAnim;
    [SerializeField] Animator richmanSilhouetteAnim;

    [SerializeField] SpriteRenderer ianLightSR;
    [SerializeField] SpriteRenderer ianSilhouetteSR;
    [SerializeField] SpriteRenderer avaLightSR;
    [SerializeField] SpriteRenderer avaSilhouetteSR;
    [SerializeField] SpriteRenderer richmanLightSR;
    [SerializeField] SpriteRenderer richmanSilhouetteSR;

    private Animator[] allAnimators;

    private float measure;
    private void Awake()
    {
        DetectionSquareThirdChorus[] detectionSquares = FindObjectsOfType<DetectionSquareThirdChorus>();


        DetectionSquareThirdChorus.GoodPoint += AddGoodPoint;
        DetectionSquareThirdChorus.PerfectPoint += AddPerfectPoint;

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
        scoreHandler.IncrementTotalPointsPartThree(true);
    }

    private void AddPerfectPoint()
    {
        scoreHandler.IncrementTotalPointsPartThree(false);
    }

    private IEnumerator CharacterAnimation()
    {
        ianLightAnim.enabled = true;
        ianLightAnim.Play("IanLight");
        ianSilhouetteAnim.enabled = true;
        ianSilhouetteAnim.Play("IanSilhouette");
        yield return new WaitForSeconds(measure * 4);
        avaLightAnim.enabled = true;
        avaLightAnim.Play("AvaLight");
        avaSilhouetteAnim.enabled = true;
        avaSilhouetteAnim.Play("AvaSilhouette");
        yield return new WaitForSeconds(measure * 4);
        richmanLightAnim.enabled = true;
        richmanLightAnim.Play("RichmanLight");
        richmanSilhouetteAnim.enabled = true;
        richmanSilhouetteAnim.Play("RichmanSilhouette");
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
        gameplayArrows.transform.localPosition = new Vector3(195f, 1571.8f, 0);

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

        ianLightAnim.enabled = false;
        ianSilhouetteAnim.enabled = false;
        ianLightSR.color = new Color(1, 1, 1, 0);
        ianSilhouetteSR.color = new Color(1, 1, 1, 1);

        avaLightAnim.enabled = false;
        avaSilhouetteAnim.enabled = false;
        avaLightSR.color = new Color(1, 1, 1, 0);
        avaSilhouetteSR.color = new Color(1, 1, 1, 1);

        richmanLightAnim.enabled = false;
        richmanSilhouetteAnim.enabled = false;
        richmanLightSR.color = new Color(1, 1, 1, 0);
        richmanSilhouetteSR.color = new Color(1, 1, 1, 1);
    }
}
