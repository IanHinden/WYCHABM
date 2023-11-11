using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehavior : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;

    [SerializeField] GameObject sittingObjects;
    [SerializeField] GameObject avaTexts;

    void Awake()
    {
        StartCoroutine(SceneTiming());
    }

    public IEnumerator SceneTiming()
    {
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(3));
        switchToAva();
    }

    private void switchToAva()
    {
        sittingObjects.SetActive(false);
        avaTexts.SetActive(true);
    }
}
