using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerDemo : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI text;

    private float waitTime = .7f;
    void Start()
    {
        StartCoroutine(SliderBehavior());
    }

    // Update is called once per frame
    IEnumerator SliderBehavior()
    {
        while (true)
        {
            slider.value = 3;
            text.text = "3";
            yield return new WaitForSeconds(waitTime);
            slider.value = 2;
            text.text = "2";
            yield return new WaitForSeconds(waitTime);
            slider.value = 1;
            text.text = "1";
            yield return new WaitForSeconds(waitTime);
            slider.value = 0;
            text.text = "0";
            yield return new WaitForSeconds(waitTime);
        }
    }
}
