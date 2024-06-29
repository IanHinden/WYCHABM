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

    public float blinkDuration = 1.5f; // Adjust the duration of the blinking effect
    public float blinkFrequency = 20f; // Adjust the frequency of the blinking
    public float finalFadeOutDuration = 1f; // Adjust the duration of the final fade-out

    private Color originalColor;

    [Header("Ava Front View Objects")]
    [SerializeField] GameObject AvaFrontView;
    [SerializeField] GameObject Eyes1;
    [SerializeField] GameObject Eyes2;
    [SerializeField] SpriteRenderer Mouth1;
    [SerializeField] SpriteRenderer Mouth2;

    private float AvaSeesRichmanTransitionDuration = .5f;

    private void Awake()
    {
        originalColor = AvaSeesRichmanEyes.color;
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

        yield return new WaitForSeconds(AvaSeesRichmanTransitionDuration);
        yield return new WaitForSeconds(2f);
        StartCoroutine(EyeSparkFade());

        yield return new WaitForSeconds(3f);
        AvaSeesRichman.SetActive(false);
        StartCoroutine(AvaFrontViewAnim());
        //Logic to switch to Richman sitting
        //Logic to switch to Giant Richman
        AvaFrontView.SetActive(true);
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

    private IEnumerator EyeSparkFade()
    {
        float blinkTimer = 0;
        bool isBlinking = true;



        while (isBlinking)
        {
            blinkTimer += Time.deltaTime;

            if (blinkTimer >= blinkDuration)
            {
                isBlinking = false;
            }
            else
            {
                float blinkState = Mathf.Floor(blinkTimer * blinkFrequency) % 2 == 0 ? 1 : 0;
                AvaSeesRichmanEyes.color = new Color(originalColor.r, originalColor.g, originalColor.b, blinkState);
            }

            yield return null;
        }

        float elapsedTime = 0;

        while (elapsedTime < finalFadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / finalFadeOutDuration);
            AvaSeesRichmanEyes.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        AvaSeesRichmanEyes.enabled = false; // Finally, disable the sprite renderer
    }

    private IEnumerator AvaFrontViewAnim()
    {

        yield return new WaitForSeconds(1);
        EyeSwitch();
        yield return new WaitForSeconds(1);
        EyeSwitch();
    }

    private void EyeSwitch()
    {
        Eyes1.SetActive(!Eyes1.activeSelf);
        Eyes2.SetActive(!Eyes2.activeSelf);
    }

    public void Reset()
    {
        
    }
}