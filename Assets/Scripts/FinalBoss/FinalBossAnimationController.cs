using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;
    [SerializeField] UIHandler uihandler;
    [SerializeField] FinalBossSFXController finalBossSFXController;

    [Header("Ava Tarts Objects")]
    [SerializeField] SpriteRenderer AvaTarts;

    [Header("Ava Sees Richman Objects")]
    [SerializeField] GameObject AvaSeesRichman;
    [SerializeField] SpriteRenderer AvaSeesRichmanHappy;
    [SerializeField] SpriteRenderer AvaSeesRichmanSad;
    [SerializeField] SpriteRenderer AvaSeesRichmanEyes;

    public float blinkDuration = 1.0f; // Adjust the duration of the blinking effect
    public float blinkFrequency = 20f; // Adjust the frequency of the blinking
    public float finalFadeOutDuration = 1f; // Adjust the duration of the final fade-out

    private Color originalColor;

    [Header("Richman Sitting Objects")]
    [SerializeField] GameObject RichmanSitting;

    [Header("Demon Richman Objects")]
    [SerializeField] GameObject DemonRichman;

    [Header("Ava Front View Objects")]
    [SerializeField] GameObject AvaFrontView;
    [SerializeField] GameObject Eyes1;
    [SerializeField] GameObject Eyes2;
    [SerializeField] SpriteRenderer Mouth1;
    [SerializeField] SpriteRenderer Mouth2;
    [SerializeField] GameObject Fist;
    [SerializeField] GameObject AvaDeterminedObjects;
    [SerializeField] GameObject AvaGiveUpObjects;

    public float raiseDuration = 3.0f;
    public float shakeAmount = 0.1f;
    public float shakeSpeed = 10.0f;
    public Vector3 fistStartPos;

    private float AvaSeesRichmanTransitionDuration = .5f;

    private void Awake()
    {
        originalColor = AvaSeesRichmanEyes.color;
        fistStartPos = Fist.transform.position;
        //StartCoroutine(SceneTiming());
    }

    public IEnumerator SceneTiming()
    { 
        // Ava Walking with Tray
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(7));

        // Ava Sees Richman
        AvaTarts.enabled = false;
        AvaSeesRichman.SetActive(true);
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(1));
        StartCoroutine(AvaSeesRichmanFade(AvaSeesRichmanHappy, AvaSeesRichmanTransitionDuration, true));
        StartCoroutine(AvaSeesRichmanFade(AvaSeesRichmanSad, AvaSeesRichmanTransitionDuration, false));
        StartCoroutine(AvaSeesRichmanFade(AvaSeesRichmanEyes, AvaSeesRichmanTransitionDuration, false));

        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(3));
        StartCoroutine(EyeSparkFade());
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(4));

        // Richman Sitting
        AvaSeesRichman.SetActive(false);
        RichmanSitting.SetActive(true);
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(4) - .5f);
        // Demon Richman
        StartCoroutine(uihandler.WhiteOutFadeIn(true, .5f));
        yield return new WaitForSeconds(.5f);
        RichmanSitting.SetActive(false);
        StartCoroutine(uihandler.WhiteOutFadeIn(false, .5f));
        DemonRichman.SetActive(true);
        yield return new WaitForSeconds(timeFunctions.ReturnCountMeasure(8) -.5f);
        StartCoroutine(uihandler.WhiteOutFadeIn(true, .5f));
        yield return new WaitForSeconds(.5f);
        // Ava Front View
        DemonRichman.SetActive(false);
        StartCoroutine(uihandler.WhiteOutFadeIn(false, .5f));
        StartCoroutine(AvaFrontViewAnim());
        AvaFrontView.SetActive(true);
        StartCoroutine(HandShake());
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

    private IEnumerator HandShake()
    {
        float raiseTimer = 0.0f;
        while (raiseTimer < raiseDuration)
        {
            raiseTimer += Time.deltaTime;
            float raiseProgress = raiseTimer / raiseDuration;

            // Raise the fist
            Fist.transform.position = Vector3.Lerp(fistStartPos, fistStartPos + Vector3.up * 4.5f, raiseProgress);

            // Shake the fist
            Fist.transform.position += (Vector3)Random.insideUnitCircle * shakeAmount * Mathf.Sin(Time.time * shakeSpeed);

            yield return null;
        }

        yield return 3f;

        Vector3 fistCurrPos = Fist.transform.position;

        float lowerTimer = 0.0f;

        SwitchToSad(true);

        while (lowerTimer < 3f)
        {
            lowerTimer += Time.deltaTime;
            float lowerProgress = lowerTimer / 3f;

            Fist.transform.position = Vector3.Lerp(fistCurrPos, fistCurrPos + Vector3.down * 8f, lowerProgress);

            yield return null;
        }
        //finalBossSFXController.PlayRichmanLaugh();
    }

    private void SwitchToSad(bool entering)
    {
        AvaDeterminedObjects.SetActive(!entering);
        AvaGiveUpObjects.SetActive(entering);
    }

    public void Reset()
    {
        
    }
}