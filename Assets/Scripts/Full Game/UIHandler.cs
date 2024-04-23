using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TimeFunctions timeFunctions;
    float singleMeasure;

    [Header("Win/Lose UI")]
    [SerializeField] Image winicon;
    [SerializeField] Image loseicon;
    [SerializeField] RhythmRatingDisplay rhythmRatingDisplay;
    Image greencircle;
    Image redx;

    [Header("Time Remaining UI")]
    [SerializeField] GameObject panel;
    [SerializeField] Slider timerSlider;
    [SerializeField] RectTransform spark;
    [SerializeField] RectTransform fillArea;
    [SerializeField] GameObject IanObjects;
    [SerializeField] Image Ian;
    [SerializeField] GameObject SkeletonObjects;
    [SerializeField] GameObject YellowSpark;
    [SerializeField] GameObject BlueSpark;
    [SerializeField] GameObject SpeechBubble;
    [SerializeField] GameObject SpeakerObjects;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] CountdownTick countdownTick;
    [SerializeField] CountdownTok countdownTok;
    [SerializeField] GameObject Countdown1;
    [SerializeField] GameObject Countdown2;
    [SerializeField] GameObject Countdown3;

    [SerializeField] TextMeshProUGUI textmesh;
    [SerializeField] TextMeshProUGUI kissHitText;

    [Header("Score UI")]
    [SerializeField] GameObject scorecard;
    [SerializeField] GameObject scorecardSlideInSFX;
    [SerializeField] GameObject scorecardSlideOutSFX;
    [SerializeField] GameObject bonusScorecard;
    [SerializeField] NumberPeopleAnimationController numberPeopleAnimationController;
    private Animator scoreCardAnim;
    private Animator bonusScorecardAnim;
    private TextMeshProUGUI scoreCardText;
    private AudioSource scorecardSlideInSFXAS;
    private AudioSource scorecardSlideOutSFXAS;

    [SerializeField] AudioSource WinRiff;
    [SerializeField] AudioSource LoseRiff;

    [SerializeField] GameObject frame;

    [SerializeField] MaskTransition mask;

    [Header("Start/Pause UI")]
    [SerializeField] GameObject pauseButton;

    [SerializeField] GameObject instructionsMenuPanel;

    [Header("Score Screen")]
    [SerializeField] TextMeshProUGUI standardScore;
    [SerializeField] TextMeshProUGUI bonusScore;

    private Animator anim;
    private Animator kissHitAnim;

    private Animator countdown1Anim;
    private Animator countdown2Anim;
    private Animator countdown3Anim;

    private Coroutine yellowSparkCo;
    private Coroutine blueSparkCo;

    private Image SpeechBubbleImage;
    private Image countdown1Image;
    private Image countdown2Image;
    private Image countdown3Image;

    // Start is called before the first frame update
    void Awake()
    {
        singleMeasure = timeFunctions.ReturnSingleMeasure();

        greencircle = winicon.GetComponent<Image>();
        redx = loseicon.GetComponent<Image>();

        textmesh.text = "";
        anim = textmesh.GetComponent<Animator>();
        kissHitAnim = kissHitText.GetComponent<Animator>();

        scoreCardAnim = scorecard.GetComponent<Animator>();
        scoreCardText = scorecard.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        bonusScorecardAnim = bonusScorecard.GetComponent<Animator>();

        scorecardSlideInSFXAS = scorecardSlideInSFX.GetComponent<AudioSource>();
        scorecardSlideOutSFXAS = scorecardSlideOutSFX.GetComponent<AudioSource>();

        countdown1Anim = Countdown1.GetComponent<Animator>();
        countdown2Anim = Countdown2.GetComponent<Animator>();
        countdown3Anim = Countdown3.GetComponent<Animator>();

        countdown1Image = Countdown1.GetComponent<Image>();
        countdown2Image = Countdown2.GetComponent<Image>();
        countdown3Image = Countdown3.GetComponent<Image>();

        SpeechBubbleImage = SpeechBubble.GetComponent<Image>();
    }

    public void HidePauseButton()
    {
        pauseButton.SetActive(false);
    }

    public void ShowPauseButton()
    {
        pauseButton.SetActive(true);
    }

    public void WinDisplay()
    {
        WinRiff.Play();
        greencircle.enabled = true;
    }

    public void LoseDisplay()
    {
        LoseRiff.Play();
        redx.enabled = true;
    }

    public void ClearWinLoss()
    {
        greencircle.enabled = false;
        redx.enabled = false;
    }

    public void ClearInstructions()
    {
        textmesh.text = "";
    }

    private void ResetSliderTimer()
    {
        timerSlider.maxValue = 4;
        timerSlider.value = 4;
    }

    public void Countdown(int totalMeasures)
    {
        StartCoroutine(TriggerCountdownAnimation(totalMeasures));
    }

    public void CountdownCheek()
    {
        StartCoroutine(TriggerCountdownCheekAnimation());
    }

    IEnumerator TriggerCountdownAnimation(int totalMeasures)
    {
        SwitchToIan();
        float totalTime = totalMeasures * singleMeasure;

        timerSlider.maxValue = totalMeasures > 3 ? totalMeasures - 1 : totalMeasures;
        timerSlider.value = totalMeasures;

        UpdateSparkPos();

        countdown.text = " ";

        while(totalTime > 3)
        {
            yield return new WaitForSeconds(singleMeasure);
            totalTime -= singleMeasure;
            timerSlider.value--;
            UpdateSparkPos();
        }

        HideOrShowSpeechBubble(true);
        //countdown.text = "3";
        countdown3Image.enabled = true;
        countdown3Anim.SetTrigger("Grow");
        countdownTick.playTick();
        timerSlider.value = 3;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        //countdown.text = "2";
        countdown3Image.enabled = false;
        countdown2Image.enabled = true;
        countdown2Anim.SetTrigger("Grow");
        countdownTok.playTok();
        timerSlider.value = 2;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        //countdown.text = "1";
        countdown2Image.enabled = false;
        countdown1Image.enabled = true;
        countdown1Anim.SetTrigger("Grow");
        countdownTick.playTick();
        timerSlider.value = 1;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        SwitchToSkeleton();
        countdown1Image.enabled = false;
        countdown.text = "";
        countdownTok.playTok();
        timerSlider.value = 0;
        UpdateSparkPos();
    }

    IEnumerator TriggerCountdownCheekAnimation()
    {
        SwitchToIan();
        float totalTime = 3 * singleMeasure;

        timerSlider.maxValue = 3;
        timerSlider.value = 3;

        UpdateSparkPos();

        countdown.text = " ";

        while (totalTime > 3)
        {
            yield return new WaitForSeconds(singleMeasure);
            totalTime -= singleMeasure;
            timerSlider.value--;
            UpdateSparkPos();
        }

        HideOrShowSpeechBubble(true);
        countdown.text = "3";
        timerSlider.value = 3;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "2";
        timerSlider.value = 2;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "1";
        timerSlider.value = 1;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "0";
        timerSlider.value = 0;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);

        countdown.text = " ";

        while (totalTime > 3)
        {
            yield return new WaitForSeconds(singleMeasure);
            totalTime -= singleMeasure;
            timerSlider.value--;
            UpdateSparkPos();
        }

        countdown.text = "3";
        timerSlider.value = 3;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "2";
        timerSlider.value = 2;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        countdown.text = "1";
        timerSlider.value = 1;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        SwitchToSkeleton();
        countdown.text = "";
        timerSlider.value = 0;
        UpdateSparkPos();
    }

    private void UpdateSparkPos()
    {
        float fillWidth = fillArea.rect.width * timerSlider.normalizedValue;
        spark.localPosition = new Vector2(fillWidth - 490.269f, spark.anchoredPosition.y);
    }

    private void SwitchToSkeleton()
    {
        HideOrShowSpeechBubble(false);
        yellowSparkCo = StartCoroutine(YellowSparkFlash());
        blueSparkCo = StartCoroutine(BlueSparkFlash());
        Ian.enabled = false;
        SkeletonObjects.SetActive(true);
    }

    private void SwitchToIan()
    {
        HideOrShowSpeechBubble(false);
        Ian.enabled = true;
        SkeletonObjects.SetActive(false);
        if(yellowSparkCo != null) { StopCoroutine(yellowSparkCo); }
        if(blueSparkCo != null) { StopCoroutine(blueSparkCo); }
    }

    private void HideOrShowSpeechBubble(bool show)
    {
        SpeechBubbleImage.enabled = show;
    }


    private IEnumerator YellowSparkFlash()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            YellowSpark.SetActive(!YellowSpark.activeInHierarchy);
        }
    }

    private IEnumerator BlueSparkFlash()
    {
        while (true)
        {
            yield return new WaitForSeconds(.08f);
            BlueSpark.SetActive(!BlueSpark.activeInHierarchy);
        }
    }

    public void setFrame(bool show)
    {
        frame.SetActive(show);
    }

    public void showSlider()
    {
        IanObjects.SetActive(true);
        SpeakerObjects.SetActive(true);
        panel.SetActive(true);
    }

    public void hideSlider()
    {
        IanObjects.SetActive(false);
        SpeakerObjects.SetActive(false);
        panel.SetActive(false);
    }

    public void InstructionText(string instructions)
    {
        StartCoroutine(AnimateAndDestroy(instructions));
    }

    public void InstructionTextKissHit(string instructions)
    {
        StartCoroutine(AnimateAndDestroyKissHit(instructions));
    }

    private IEnumerator AnimateAndDestroy(string instructions)
    {
        yield return new WaitForSeconds(.6f);
        textmesh.text = instructions;
        anim.SetBool("Animate", true);
        yield return new WaitForSeconds(2f);
        textmesh.text = "";
        anim.SetBool("Animate", false);
    }

    private IEnumerator AnimateAndDestroyKissHit(string instructions)
    {
        yield return new WaitForSeconds(.3f);
        kissHitText.text = instructions;
        kissHitAnim.SetBool("Animate", true);
        yield return new WaitForSeconds(1.5f);
        kissHitText.text = "";
        kissHitAnim.SetBool("Animate", false);
    }

    public IEnumerator DisplayScoreCard(int score)
    {
        int prevscore = score - 1;
        scoreCardText.text = prevscore.ToString();
        scoreCardAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.3f);
        scorecardSlideInSFXAS.Play();
        yield return new WaitForSeconds(.5f);
        scoreCardText.text = score.ToString();
        StartCoroutine(HideScoreCard());
        yield return new WaitForSeconds(1.5f);
        scorecardSlideOutSFXAS.Play();
    }

    public IEnumerator DisplayScoreCardTwo(int score)
    {
        int prevscore = score - 2;
        int midscore = score - 1;
        scoreCardText.text = prevscore.ToString();
        scoreCardAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.3f);
        scorecardSlideInSFXAS.Play();
        yield return new WaitForSeconds(.5f);
        scoreCardText.text = midscore.ToString();
        yield return new WaitForSeconds(.4f);
        scoreCardText.text = score.ToString();
        StartCoroutine(HideScoreCard());
        yield return new WaitForSeconds(1.5f);
        scorecardSlideOutSFXAS.Play();
    }
    IEnumerator HideScoreCard()
    {
        yield return new WaitForSeconds(1.3f);
        scoreCardAnim.SetTrigger("Exit");
    }


    public IEnumerator DisplayBonusScoreCard(int numberPerson)
    {
        bonusScorecardAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.5f);
        numberPeopleAnimationController.NPActivate(numberPerson);
        yield return new WaitForSeconds(2.5f);
        bonusScorecardAnim.SetTrigger("Exit");
    }

    public void MaskOutro(Vector2 maskCoordinates)
    {
        StartCoroutine(mask.TransitionOutro(maskCoordinates));
    }

    public void MaskIntro(Vector2 maskCoordinates)
    {
        StartCoroutine(mask.TransitionIntro(maskCoordinates));
    }

    public void HideStartButton()
    {
        instructionsMenuPanel.SetActive(false);
    }

    public void SetScoreScreenStandardScore(string score)
    {
        standardScore.text = score;
    }

    public void SetScoreScreenBonusScore(string score)
    {
        bonusScore.text = score;
    }

    private void ClearSetScoreScreenText()
    {
        standardScore.text = "";
        bonusScore.text = "";
    }

    public void ClearRhythmRating()
    {
        rhythmRatingDisplay.ClearText();
    }

    public void Reset()
    {
        ClearWinLoss();
        setFrame(false);
        hideSlider();
        ClearInstructions();
        ClearSetScoreScreenText();
        HidePauseButton();
        ClearRhythmRating();
    }
}
