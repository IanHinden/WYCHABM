﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionMenu3AnimationController : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;
    float singleMeasure;

    [SerializeField] RectTransform spark;
    [SerializeField] RectTransform fillArea;

    [SerializeField] Slider timerSlider;
    [SerializeField] Slider timerSliderBG;

    [SerializeField] Image speechBubble;
    [SerializeField] GameObject Countdown1;
    [SerializeField] GameObject Countdown2;
    [SerializeField] GameObject Countdown3;

    private Animator countdown1Anim;
    private Animator countdown2Anim;
    private Animator countdown3Anim;

    private Image countdown1Image;
    private Image countdown2Image;
    private Image countdown3Image;

    private void Awake()
    {
        singleMeasure = timeFunctions.ReturnSingleMeasure();

        countdown1Anim = Countdown1.GetComponent<Animator>();
        countdown2Anim = Countdown2.GetComponent<Animator>();
        countdown3Anim = Countdown3.GetComponent<Animator>();

        countdown1Image = Countdown1.GetComponent<Image>();
        countdown2Image = Countdown2.GetComponent<Image>();
        countdown3Image = Countdown3.GetComponent<Image>();

        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            float totalTime = 6 * singleMeasure;
            timerSlider.maxValue = 6;
            timerSlider.value = 6;

            timerSliderBG.maxValue = 6;
            timerSliderBG.value = 6;
            UpdateSparkPos();

            while (totalTime > 3)
            {
                yield return new WaitForSeconds(singleMeasure);
                totalTime -= singleMeasure;
                timerSlider.value--;
                timerSliderBG.value--;
                UpdateSparkPos();
            }

            HideOrShowSpeechBubble(true);
            countdown3Image.enabled = true;
            countdown3Anim.SetTrigger("Grow");
            timerSlider.value = 3;
            timerSliderBG.value = 3;
            UpdateSparkPos();

            yield return new WaitForSeconds(singleMeasure);
            countdown3Image.enabled = false;
            countdown2Image.enabled = true;
            countdown2Anim.SetTrigger("Grow");
            timerSlider.value = 2;
            timerSliderBG.value = 2;
            UpdateSparkPos();

            yield return new WaitForSeconds(singleMeasure);
            countdown2Image.enabled = false;
            countdown1Image.enabled = true;
            countdown1Anim.SetTrigger("Grow");
            timerSlider.value = 1;
            timerSliderBG.value = 1;
            UpdateSparkPos();

            yield return new WaitForSeconds(singleMeasure);
            HideOrShowSpeechBubble(false);
            countdown1Image.enabled = false;
            timerSlider.value = 0;
            timerSliderBG.value = 0;
            UpdateSparkPos();

            yield return new WaitForSeconds(3f);
        }
    }

    private void HideOrShowSpeechBubble(bool show)
    {
        speechBubble.enabled = show;
    }

    private void UpdateSparkPos()
    {
        float fillWidth = fillArea.rect.width * timerSlider.normalizedValue;
        spark.localPosition = new Vector2(fillWidth - 120f, spark.anchoredPosition.y);
    }
}
