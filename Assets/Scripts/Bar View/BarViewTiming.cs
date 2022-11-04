using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarViewTiming : MonoBehaviour
{
    [SerializeField] TimeFunctions timefunctions;

    private float measureMS;

    [SerializeField] private GameObject barScene;
    [SerializeField] private GameObject cellPhone;
    Animator cellPhoneAnim;
    Animator barSceneAnim;

    SpriteRenderer manStaring;

    void Awake()
    {
        measureMS = timefunctions.ReturnSingleMeasure();

        cellPhoneAnim = cellPhone.GetComponent<Animator>();
        barSceneAnim = barScene.transform.GetChild(2).GetComponent<Animator>();

        manStaring = FindObjectOfType<ManStaring>().GetComponent<SpriteRenderer>();
        StartCoroutine(timedEvents());
    }

    private IEnumerator timedEvents()
    {
        yield return new WaitForSeconds(4 * measureMS);
        cellPhone.SetActive(true);
        barScene.SetActive(true);
        manStaring.enabled = false;

        yield return new WaitForSeconds(4 * measureMS);
        cellPhoneAnim.SetTrigger("Lower");

        yield return new WaitForSeconds(2 * measureMS);
        barSceneAnim.SetTrigger("Blink");
    }
}
