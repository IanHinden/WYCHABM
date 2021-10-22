using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class ThreeSecondsLeft : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textmesh;
    [SerializeField] GameObject scoreCard;
    [SerializeField] GameObject bonusScoreCard;
    [SerializeField] GameObject winAndLossIcons;
    [SerializeField] GameObject fullSlider;
    
    private Slider timerSlider;

    private Animator scoreCardAnim;
    private Animator bonusScoreCardAnim;
    private TextMeshProUGUI scoreCardTextMesh;

    private float BPM = 85f;
    private float measureMS;

    private float score = 0;
    private float bonusScore = 0;

    private Image greenCircleImage;
    private Image redXImage;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this);
        measureMS = 60 / BPM;

        timerSlider = fullSlider.transform.GetChild(1).GetComponent<Slider>();

        scoreCardAnim = scoreCard.GetComponent<Animator>();
        scoreCardTextMesh = scoreCard.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        bonusScoreCardAnim = bonusScoreCard.GetComponent<Animator>();

        greenCircleImage = winAndLossIcons.transform.GetChild(0).GetComponent<Image>();
        redXImage = winAndLossIcons.transform.GetChild(1).GetComponent<Image>();
    }

    private void ResetSliderTimer()
    {
        timerSlider.maxValue = 4;
        timerSlider.value = 4;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetSliderTimer();
        textmesh.text = "";
        greenCircleImage.enabled = false;
        redXImage.enabled = false;
    }

    public float ReturnBPM()
    {
        return BPM;
    }

    public float ReturnSingleMeasure()
    {
        return measureMS;
    }

    public float ReturnTimeToEnd()
    {
        return measureMS * 4;
    }

    public float ReturnScore()
    {
        return score;
    }

    public float ReturnBonusScore()
    {
        return bonusScore;
    }

    public void StartCountdown()
    {
        StartCoroutine(TriggerCountdownAnimation(BPM));
    }

    IEnumerator TriggerCountdownAnimation(float BPM)
    {
        textmesh.text = "3";
        timerSlider.value = 3;

        yield return new WaitForSeconds(measureMS);
        textmesh.text = "2";
        timerSlider.value = 2;

        yield return new WaitForSeconds(measureMS);
        textmesh.text = "1";
        timerSlider.value = 1;

        yield return new WaitForSeconds(measureMS);
        textmesh.text = "0";
        timerSlider.value = 0;
    }

    public void showSlider()
    {
        fullSlider.SetActive(true);
    }

    public void hideSlider()
    {
        fullSlider.SetActive(false);
    }

    public void DisplayScoreCard()
    {
        score++;
        scoreCardTextMesh.text = score.ToString();
        scoreCardAnim.SetTrigger("Enter");
        StartCoroutine(HideScoreCard());
    }

    IEnumerator HideScoreCard()
    {
        yield return new WaitForSeconds(2);
        scoreCardAnim.SetTrigger("Exit");
    }

    public void DisplayBonusScoreCard(Animator anim)
    {
        bonusScore++;
        anim.SetTrigger("FadeIn");
        bonusScoreCardAnim.SetTrigger("Enter");
        StartCoroutine(HideBonusScoreCard());
    }

    IEnumerator HideBonusScoreCard()
    {
        yield return new WaitForSeconds(4);
        bonusScoreCardAnim.SetTrigger("Exit");
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void WinDisplay()
    {
        greenCircleImage.enabled = true;
    }

    public void LoseDisplay()
    {
        redXImage.enabled = true;
    }
}
