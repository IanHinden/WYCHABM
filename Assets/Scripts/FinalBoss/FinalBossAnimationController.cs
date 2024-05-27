using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;

    [SerializeField] SpriteRenderer AvaTarts;

    [Header("Ava Sees Richman Objects")]
    [SerializeField] GameObject AvaSeesRichman;
    [SerializeField] SpriteRenderer AvaSeesRichmanHappy;
    [SerializeField] SpriteRenderer AvaSeesRichmanSad;
    [SerializeField] SpriteRenderer AvaSeesRichmanEyes;

    [Header("Ava Front View Objects")]
    [SerializeField] GameObject AvaFrontView;

    private float AvaSeesRichmanTransitionDuration = .5f;

    private void Awake()
    {
        StartCoroutine(SceneTiming());
    }

    public IEnumerator SceneTiming()
    {
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(4));
        AvaTarts.enabled = false;
        AvaSeesRichman.SetActive(true);
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(1));
        StartCoroutine(AvaSeesRichmanFade(AvaSeesRichmanHappy, AvaSeesRichmanTransitionDuration, true));
        StartCoroutine(AvaSeesRichmanFade(AvaSeesRichmanSad, AvaSeesRichmanTransitionDuration, false));
        StartCoroutine(AvaSeesRichmanFade(AvaSeesRichmanEyes, AvaSeesRichmanTransitionDuration, false));
    }

    private IEnumerator AvaSeesRichmanFade(SpriteRenderer spriteRend, float fadeDuration, bool inOrOut)
    {
        float elapsedTime = 0;
        Color originalColor = spriteRend.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = inOrOut ? Mathf.Lerp(1, 0, elapsedTime / fadeDuration) : Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            spriteRend.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
    }
}