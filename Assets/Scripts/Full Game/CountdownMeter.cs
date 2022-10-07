using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CountdownMeter : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Slider timerSlider;
    [SerializeField] TextMeshProUGUI countdown;

    private void ResetSliderTimer()
    {
        timerSlider.maxValue = 4;
        timerSlider.value = 4;
    }

    public void Countdown(float timebetween)
    {
        StartCoroutine(TriggerCountdownAnimation(timebetween));
    }

    IEnumerator TriggerCountdownAnimation(float timebetween)
    {
        countdown.text = "3";
        timerSlider.value = 3;

        yield return new WaitForSeconds(timebetween);
        countdown.text = "2";
        timerSlider.value = 2;

        yield return new WaitForSeconds(timebetween);
        countdown.text = "1";
        timerSlider.value = 1;

        yield return new WaitForSeconds(timebetween);
        countdown.text = "0";
        timerSlider.value = 0;
    }

    public void showSlider()
    {
        panel.SetActive(true);
    }

    public void hideSlider()
    {
        panel.SetActive(false);
    }
}
