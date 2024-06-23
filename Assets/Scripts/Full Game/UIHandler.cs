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
    [SerializeField] Slider timerSliderBG;
    [SerializeField] RectTransform spark;
    [SerializeField] RectTransform fillArea;
    [SerializeField] GameObject IanObjects;
    [SerializeField] Image Ian;
    [SerializeField] GameObject SkeletonObjects;
    [SerializeField] GameObject YellowSpark;
    [SerializeField] GameObject BlueSpark;
    [SerializeField] GameObject SpeechBubble;
    [SerializeField] GameObject SpeakerObjects;
    [SerializeField] CountdownTick countdownTick;
    [SerializeField] CountdownTok countdownTok;
    [SerializeField] GameObject Countdown1;
    [SerializeField] GameObject Countdown2;
    [SerializeField] GameObject Countdown3;

    [SerializeField] TextMeshProUGUI textmesh;
    [SerializeField] TextMeshProUGUI kissHitText;

    [Header("Instruction SFX")]
    [SerializeField] InstructionSFXController instructionSFXController;

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

    private bool reset = false;


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

        timerSliderBG.maxValue = 4;
        timerSliderBG.value = 4;
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
        reset = false;
        SwitchToIan();
        float totalTime = totalMeasures * singleMeasure;

        timerSlider.maxValue = totalMeasures > 3 ? totalMeasures - 1 : totalMeasures;
        timerSlider.value = totalMeasures;

        timerSliderBG.maxValue = totalMeasures > 3 ? totalMeasures - 1 : totalMeasures;
        timerSliderBG.value = totalMeasures;

        UpdateSparkPos();

        while(totalTime > 3)
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
        if (reset == false)
        {
            countdownTick.playTick();
        }
        timerSlider.value = 3;
        timerSliderBG.value = 3;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        countdown3Image.enabled = false;
        countdown2Image.enabled = true;
        countdown2Anim.SetTrigger("Grow");
        if (reset == false)
        {
            countdownTok.playTok();
        }
        timerSlider.value = 2;
        timerSliderBG.value = 2;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        countdown2Image.enabled = false;
        countdown1Image.enabled = true;
        countdown1Anim.SetTrigger("Grow");
        if (reset == false)
        {
            countdownTick.playTick();
        }
        timerSlider.value = 1;
        timerSliderBG.value = 1;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);
        SwitchToSkeleton();
        countdown1Image.enabled = false;
        countdownTok.playTok();
        timerSlider.value = 0;
        timerSliderBG.value = 0;
        UpdateSparkPos();
    }

    IEnumerator TriggerCountdownCheekAnimation()
    {
        SwitchToIan();
        float totalTime = 3 * singleMeasure;

        timerSlider.maxValue = 3;
        timerSlider.value = 3;

        timerSliderBG.maxValue = 3;
        timerSliderBG.value = 3;

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
        countdown1Image.enabled = false;
        timerSlider.value = 0;
        timerSliderBG.value = 0;
        UpdateSparkPos();

        yield return new WaitForSeconds(singleMeasure);

        while (totalTime > 3)
        {
            yield return new WaitForSeconds(singleMeasure);
            totalTime -= singleMeasure;
            timerSlider.value--;
            timerSliderBG.value--;
            UpdateSparkPos();
        }

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
        SwitchToSkeleton();
        countdown1Image.enabled = false;
        timerSlider.value = 0;
        timerSliderBG.value = 0;
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

    public void InstructionText(string instructions, int instructionsSFX = 0)
    {
        StartCoroutine(AnimateAndDestroy(instructions, instructionsSFX));
    }

    public void InstructionTextKissHit(string instructions, int instructionSFX = 0)
    {
        StartCoroutine(AnimateAndDestroyKissHit(instructions, instructionSFX));
    }

    private IEnumerator AnimateAndDestroy(string instructions, int sfx = 0)
    {
        reset = false;
        instructionSFXController.SetAllVolume(.35f);
        yield return new WaitForSeconds(.6f);
        if (reset == false)
        {
            textmesh.text = instructions;
        }
        anim.SetBool("Animate", true);
        
        instructionSFXController.PlaySound(sfx);
        yield return new WaitForSeconds(2f);
        textmesh.text = "";
        anim.SetBool("Animate", false);
    }

    private IEnumerator AnimateAndDestroyKissHit(string instructions, int sfx = 0)
    {
        reset = false;
        instructionSFXController.SetAllVolume(.35f);
        yield return new WaitForSeconds(.3f);
        if (reset == false)
        {
            kissHitText.text = instructions;
        }
        kissHitAnim.SetBool("Animate", true);
        instructionSFXController.PlaySound(sfx);
        yield return new WaitForSeconds(1.5f);
        kissHitText.text = "";
        kissHitAnim.SetBool("Animate", false);
    }

    public IEnumerator DisplayScoreCard(int score)
    {
        reset = false;
        if(scoreCardText.text == "")
        {
            scoreCardText.text = "0";
        }

        scorecardSlideInSFXAS.volume = 1;
        scorecardSlideOutSFXAS.volume = 1;

        scorecard.GetComponent<Image>().enabled = true;
        int prevscore = score - 1;
        scoreCardText.text = prevscore.ToString();
        scoreCardAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.3f);
        scorecardSlideInSFXAS.Play();
        yield return new WaitForSeconds(.5f);
        if (reset == false)
        {
            scoreCardText.text = score.ToString();
        }
        StartCoroutine(HideScoreCard());
        yield return new WaitForSeconds(1.5f);
        scorecardSlideOutSFXAS.Play();
    }

    public IEnumerator DisplayScoreCardTwo(int score)
    {
        reset = false;
        if (scoreCardText.text == "")
        {
            scoreCardText.text = "0";
        }

        scorecardSlideInSFXAS.volume = 1;
        scorecardSlideOutSFXAS.volume = 1;

        int prevscore = score - 2;
        int midscore = score - 1;
        scoreCardText.text = prevscore.ToString();
        scoreCardAnim.SetTrigger("Enter");
        yield return new WaitForSeconds(.3f);
        scorecardSlideInSFXAS.Play();
        yield return new WaitForSeconds(.5f);
        scoreCardText.text = midscore.ToString();
        yield return new WaitForSeconds(.4f);
        if (reset == false)
        {
            scoreCardText.text = score.ToString();
        }
        StartCoroutine(HideScoreCard());
        yield return new WaitForSeconds(1.5f);
        scorecardSlideOutSFXAS.Play();
    }
    IEnumerator HideScoreCard()
    {
        yield return new WaitForSeconds(1.3f);
        scoreCardAnim.SetTrigger("Exit");
    }

    public void QuickRemoveScoreCard()
    {
        reset = true;
        scoreCardText.text = "";
        scorecard.GetComponent<Image>().enabled = false;

        scorecardSlideInSFXAS.volume = 0;
        scorecardSlideOutSFXAS.volume = 0;

        bonusScorecard.GetComponent<Image>().enabled = false;
        foreach (Transform child in bonusScorecard.transform)
        {
            Image image = child.GetComponent<Image>();

            if (image != null)
            {
                image.enabled = false;
            }
        }

        textmesh.text = "";
        instructionSFXController.SetAllVolume(0);
    }


    public IEnumerator DisplayBonusScoreCard(int numberPerson)
    {
        bonusScorecard.GetComponent<Image>().enabled = true;
        foreach (Transform child in bonusScorecard.transform)
        {
            Image image = child.GetComponent<Image>();

            if (image != null)
            {
                image.enabled = true;
            }
        }

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
        HidePauseButton();
        ClearRhythmRating();
    }
}
