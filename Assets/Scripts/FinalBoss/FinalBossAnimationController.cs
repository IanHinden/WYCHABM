using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;

    [SerializeField] SpriteRenderer AvaTarts;
    [SerializeField] GameObject AvaSeesRichman;
    private void Awake()
    {
        StartCoroutine(SceneTiming());
    }

    public IEnumerator SceneTiming()
    {
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(4));
        AvaTarts.enabled = false;
        AvaSeesRichman.SetActive(true);
    }
}
