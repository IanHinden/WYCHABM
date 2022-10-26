using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsAnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;
    [SerializeField] GameObject SpaceUp;
    [SerializeField] GameObject SpaceDown;

    private float measure;

    void Awake()
    {
        SetSpacebar(true);
        measure = timefunctions.ReturnSingleMeasure();
        StartCoroutine(SpaceAnimator());
    }

    private void SetSpacebar(bool up)
    {
        SpaceUp.SetActive(up);
        SpaceDown.SetActive(!up);
    }

    // Update is called once per frame
    private IEnumerator SpaceAnimator()
    {
        yield return new WaitForSeconds(measure);
        SetSpacebar(true);

        yield return new WaitForSeconds(measure);
        SetSpacebar(false);

        yield return new WaitForSeconds(measure);
        SetSpacebar(true);

        yield return new WaitForSeconds(measure);
        SetSpacebar(false);

        yield return new WaitForSeconds(measure);
        SetSpacebar(true);
    }
}
